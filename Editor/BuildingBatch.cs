using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
namespace TRNTH
{
    [System.Serializable]public class BuildingBatch{
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
            buildPlayerOptions.locationPathName = RootPath+"Mac/"+Application.productName;
            buildPlayerOptions.target = BuildTarget.StandaloneOSX;
            buildPlayerOptions.options = BuildOptions.None;
            Debug.Log(BuildPipeline.BuildPlayer(buildPlayerOptions)) ;
        }
         public void BuildWindows(){
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = getAllScenePath();
            buildPlayerOptions.locationPathName = RootPath+"Windows/"+Application.productName+".exe";
            buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
            buildPlayerOptions.options = BuildOptions.None;
            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }
        public bool Mac=true;
        public bool Windows=true;
        public string versionPrefix="0.1.";
        public const int Max=1000;
        public int VersionNumber;
        public void Start(){
            VersionNumber%=Max;
            if(Mac)MacBuild();
            if(Windows)BuildWindows();
            PlayerSettings.bundleVersion=versionPrefix+VersionNumber++;
        }
    }
}