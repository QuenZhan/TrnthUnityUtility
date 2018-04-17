using UnityEditor;
using UnityEngine;
namespace TRNTH
{
    public class BuildingBatchWindow : EditorWindow {
    
        [MenuItem("TRNTH/BuildingBatch")]
        private static void ShowWindow() {
            GetWindow<BuildingBatchWindow>().Show();
        }
        BuildingBatch _BuildingBatch=new BuildingBatch();
        private void OnGUI() {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Version Prefix : ");
            _BuildingBatch.versionPrefix=GUILayout.TextField(_BuildingBatch.versionPrefix);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label(_BuildingBatch.VersionNumber.ToString());
            _BuildingBatch.VersionNumber=(int)GUILayout.HorizontalSlider(_BuildingBatch.VersionNumber,0,BuildingBatch.Max);
            GUILayout.EndHorizontal();
            _BuildingBatch.Mac=GUILayout.Toggle(_BuildingBatch.Mac,"MAC");
            _BuildingBatch.Windows=GUILayout.Toggle(_BuildingBatch.Windows,"Windows");
            if(GUILayout.Button("Build "+_BuildingBatch.versionPrefix+_BuildingBatch.VersionNumber)){
                _BuildingBatch.Start();
            }
        }
        const string fileName="_BuildingBatchSetting";
        private void Awake() {
            var loader=new DiskSaveLoad();
            _BuildingBatch=loader.LoadFromFile<BuildingBatch>(fileName);
            if(_BuildingBatch==null)_BuildingBatch=new BuildingBatch();
        }
        private void OnDestroy() {
            var loader=new DiskSaveLoad();
            loader.SaveToFile(_BuildingBatch,fileName);
        }
    }
}