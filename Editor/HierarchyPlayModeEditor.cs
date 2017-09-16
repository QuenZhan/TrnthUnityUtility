using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.SceneManagement;

namespace TRNTH{
	public class HierarchyPlayModeEditor : EditorWindowBase {
		[MenuItem("TRNTH/PlayModeEditor")]
		static void ShowWindow(){
			var win=new HierarchyPlayModeEditor();
			win.Show();
			win.titleContent=new GUIContent("TRNTHPlayModeEditor");
		}
		void OnSelectionChange(){
			CheckData();
		}
		void CheckData(){
			if(!EditorApplication.isPlaying)return;
			var tag="[RuntimeEditing]";
			if(_Parent==null){
				foreach(var e in EditorSceneManager.GetActiveScene().GetRootGameObjects()){
					if(!e.name.Contains(tag))continue;
					_Parent=e.transform;
					break;
				}
			}
			if(_Parent==null){
				GUIContent gUIContent=new GUIContent("PlayModeEditor 沒有指定要紀錄誰");
				EditorWindow.focusedWindow.ShowNotification(gUIContent);
				return;
			}
			_Parent.name=_Parent.name.Replace(tag,string.Empty);
			_Parent.name=_Parent.name+tag;
			if(_Parent.parent!=null){
				GUIContent gUIContent=new GUIContent("Parent 不可以有爸爸");
				EditorWindow.focusedWindow.ShowNotification(gUIContent);
				return;
			}
		}
		protected virtual GameObject Replace(GameObject _Parent){
			if(_Parent==null)return null;
			var prefab=(GameObject)AssetDatabase.LoadAssetAtPath(TmpPrefabPath,typeof(GameObject));
			var newOne=PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			newOne.name=_Parent.gameObject.name;
			newOne.transform.position=_Parent.transform.position;
			DestroyImmediate(_Parent.gameObject);
			PrefabUtility.DisconnectPrefabInstance(newOne);
			EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
			return newOne;
		}
		void OnFocus(){
			EditorApplication.playmodeStateChanged-=StateChanged;
			EditorApplication.playmodeStateChanged+=StateChanged;
		}
		bool AutoPipeline=true;
		private void StateChanged()
		{
			if(!AutoPipeline)return;
			if (!EditorApplication.isPlayingOrWillChangePlaymode 
			&& EditorApplication.isPlaying 
			){
				RecordSerialized();
			}
			if(EditorApplication.isPlaying || EditorApplication.isPlayingOrWillChangePlaymode){
				return;
			}
			_Parent=Replace(_Parent.gameObject).transform;
		}

		[SerializeField]Transform _Parent;
		void OnGUI()
		{
			EditorGUILayout.LabelField("保持這個介面顯示，Parent 底下的所有孩子的\n任何變動將會在 Play Mode 之後保留。");
			PropertyDrawer("_Parent",this);
			AutoPipeline=GUILayout.Toggle(AutoPipeline,"AutoPipeline");
			if(AutoPipeline)return;
			if(GUILayout.Button("Replace")){
				_Parent=Replace(_Parent.gameObject).transform;
			}
			if(GUILayout.Button("RecordSerialized")){
				RecordSerialized(_Parent.gameObject);
			}
		}
		const string TmpPrefabPath="Assets/_DungeonMealCore/Terrain/TmpPrefab.prefab";
		void RecordSerialized(){
			RecordSerialized(_Parent.gameObject);
		}
		protected virtual void RecordSerialized(GameObject gameObject){
			var path=string.Format(TmpPrefabPath,Application.dataPath);
			PrefabUtility.CreatePrefab(path,gameObject);
		}

	}
}
