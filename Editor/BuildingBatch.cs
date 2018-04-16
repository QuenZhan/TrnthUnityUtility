using UnityEditor;
using System.Collections.Generic;
namespace TRNTH
{
    public class BuildingBatch{
        public string RootPath="";
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
            buildPlayerOptions.locationPathName = "Mac/";
            buildPlayerOptions.target = BuildTarget.StandaloneOSX;
            buildPlayerOptions.options = BuildOptions.None;
            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }
         public void BuildWindows(){
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = getAllScenePath();
            buildPlayerOptions.locationPathName = "Windows/";
            buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
            buildPlayerOptions.options = BuildOptions.None;
            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }
        [MenuItem("TRNTH/BuildingBatch/Start")]
            
        static void _Start(){
            var instance=new BuildingBatch();
            instance.Start();
        }
        public void Start(){
            MacBuild();
            BuildWindows();
        }
    }
}