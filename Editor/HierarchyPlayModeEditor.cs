using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.SceneManagement;
using TRNTH.DungeonMeal;

namespace TRNTH{
	public class HierarchyPlayModeEditor : EditorWindowBase {
		// static HierarchyPlayModeEditor Instance;		
		void OnInspectorUpdate(){
			var dt=0.16f;
			// if(_replaceCounter>0){
			// 	_replaceCounter-=dt;
			// 	if(_replaceCounter<=0 && _Parent){
			// 		_Parent=Replace(_Parent.gameObject).transform;
			// 	}
			// }
			if(!EditorApplication.isPlaying || !AutoPipeline)return;
			counter-=dt;
			if(counter<0){
				counter=120;
				RecordSerialized();
			}
		}
		[MenuItem("TRNTH/PlayModeEditor/Show Window")]static void ShowWindow(){
			GetWindow<HierarchyPlayModeEditor>().Show();
			// var win=new HierarchyPlayModeEditor();
			// win.Show();
			// win.titleContent=new GUIContent("TRNTHPlayModeEditor");
			// Instance=win;
		}
		void OnSelectionChange(){
			CheckData();
		}
		float counter;
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
		[SerializeField]GameObject _prefab;
		protected virtual GameObject Replace(GameObject _Parent){
			if(_Parent==null){
				GUIContent gUIContent=new GUIContent("_Parent==null");
				ShowNotification(gUIContent);
				return null;
			}
			var currentScene=EditorSceneManager.GetActiveScene();
			// var prefab=(GameObject)AssetDatabase.LoadAssetAtPath(string.Format(TmpPrefabPath,currentScene.name),typeof(GameObject));
			var prefab=_prefab;
			if(prefab==null){
				GUIContent gUIContent=new GUIContent("Prefab==null");
				ShowNotification(gUIContent);
				return _Parent;
			}
			var newOne=PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			newOne.name=_Parent.gameObject.name;
			newOne.transform.position=_Parent.transform.position;
			DestroyImmediate(_Parent.gameObject);
			PrefabUtility.DisconnectPrefabInstance(newOne);
			EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
			return newOne;
		}
		// [SerializeField]bool _manual;
		void OnFocus(){			
			EditorApplication.playModeStateChanged-=StateChanged;
			EditorApplication.playModeStateChanged+=StateChanged;
			BattleManager.CanLoadScene=false;
		}
		void OnDestroy()
		{
			BattleManager.CanLoadScene=true;
		}
		bool AutoPipeline=true;
		private void StateChanged(PlayModeStateChange playmode)
		{
			if(!AutoPipeline || !this)return;
			if (!EditorApplication.isPlayingOrWillChangePlaymode 
			&& EditorApplication.isPlaying 
			){
				RecordSerialized();
			}
			if(EditorApplication.isPlaying || EditorApplication.isPlayingOrWillChangePlaymode){
				return;
			}
			// _Parent=Replace(_Parent.gameObject).transform;
			_replaceCounter=1;
		}
		float _replaceCounter=0;

		[SerializeField]Transform _Parent;
		// [SerializeField]FoodData _foodData;
		// const string 
		const string Str_Parent="_Parent";
		const string str_foodData="_foodData";
		const string str_AutoPipeline="AutoPipeline";
		const string str_Replace="Load (alt+L)";
		const string str_RecordSerialized="Save (alt+S)";
		void OnGUI()
		{
			// EditorGUILayout.LabelField("保持這個介面顯示，Parent 底下的所有孩子的\n任何變動將會在 Play Mode 之後保留。");
			PropertyDrawer(Str_Parent,this);
			PropertyDrawer(str_foodData,this);
			AutoPipeline=GUILayout.Toggle(AutoPipeline,str_AutoPipeline);
			if(AutoPipeline)return;
			if(_Parent){
				if(GUILayout.Button(str_RecordSerialized)){
					RecordSerialized(_Parent.gameObject);
				}
			}
			if(_prefab){
				if(GUILayout.Button(str_Replace)){
					_Parent=Replace(_Parent.gameObject).transform;
				}
			}
			GUILayout.Label("Save file here:");
			PropertyDrawer("_prefab",this);
		}
		
		const string TmpPrefabPath="Assets/_DungeonMealCore/Terrain/{0}.prefab";
		[MenuItem("TRNTH/PlayModeEditor/Save &s")]
		static void Save(){
			GetWindow<HierarchyPlayModeEditor>().RecordSerialized();
			// if(Instance)Instance.RecordSerialized();
		}
		[MenuItem("TRNTH/PlayModeEditor/Load &l")]
		static void Replace(){
			var window=GetWindow<HierarchyPlayModeEditor>();
			window._Parent=window.Replace(window._Parent.gameObject).transform;
		}
		void RecordSerialized(){
			if(_Parent==null)return;
			RecordSerialized(_Parent.gameObject);
		}
		protected virtual void RecordSerialized(GameObject gameObject){
			if(gameObject==null)return;
			var currentScene=UnityEngine.SceneManagement.SceneManager.GetActiveScene();
			var path=string.Format(string.Format(TmpPrefabPath,currentScene.name),Application.dataPath);
			_prefab=PrefabUtility.CreatePrefab(path,gameObject);
		}

	}
}
