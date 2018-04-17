using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
namespace TRNTH
{
    public class BuildingBatch{
        public string RootPath="Builds/";
        string[] getAllScenePath(){
            var list=new List<string>();
            foreach(var e in EditorBuildSettings.scenes){
                if(!e.enabled)continue;
                list.Add(e.path);
            }
            return list.ToArray();
        }
        public void MacBuild(){
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = getAllScenePath();
            buildPlayerOptions.target = BuildTarget.StandaloneOSX;
            buildPlayerOptions.locationPathName = RootPath+"MacDev/"+Application.productName;
            buildPlayerOptions.options=BuildOptions.Development  | BuildOptions.ConnectWithProfiler | BuildOptions.AllowDebugging;
            Debug.Log(BuildPipeline.BuildPlayer(buildPlayerOptions)) ;
            buildPlayerOptions.locationPathName = RootPath+"Mac/"+Application.productName;
            buildPlayerOptions.options = BuildOptions.None;
            Debug.Log(BuildPipeline.BuildPlayer(buildPlayerOptions)) ;
        }
         public void BuildWindows(){
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = getAllScenePath();
            buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
            buildPlayerOptions.locationPathName = RootPath+"WindowsDev/"+Application.productName+".exe";
            buildPlayerOptions.options=BuildOptions.Development  | BuildOptions.ConnectWithProfiler | BuildOptions.AllowDebugging;
            var result=BuildPipeline.BuildPlayer(buildPlayerOptions);
            buildPlayerOptions.locationPathName = RootPath+"Windows/"+Application.productName+".exe";
            buildPlayerOptions.options = BuildOptions.None;
            result=BuildPipeline.BuildPlayer(buildPlayerOptions);
            Debug.Log(result);
        }
        public bool Mac=true;
        public bool Windows=true;
        public bool DebugBuild;
        public string versionPrefix{
            get{
                var key="versionPrefix";
                if(!PlayerPrefs.HasKey(key)){
                    versionPrefix="0.1.";
                }
                return PlayerPrefs.GetString(key);
            }
            set{PlayerPrefs.SetString("versionPrefix",value);}
        }
        public const int Max=1000;
        public int VersionNumber{
            get{return PlayerPrefs.GetInt("BuildNumber");}
            set{PlayerPrefs.SetInt("BuildNumber",value);}
        }
        public void Start(){
            VersionNumber%=Max;
            if(Mac)MacBuild();
            if(Windows)BuildWindows();
            PlayerSettings.bundleVersion=versionPrefix+VersionNumber++;
        }
    }
}