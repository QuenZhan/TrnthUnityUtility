using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.SceneManagement;
using TRNTH.DungeonMeal;

namespace TRNTH{
	public class HierarchyPlayModeEditor : EditorWindowBase {
		static HierarchyPlayModeEditor Instance;		
		void OnInspectorUpdate(){
			var dt=0.16f;
			if(_replaceCounter>0){
				_replaceCounter-=dt;
				if(_replaceCounter<=0 && _Parent){
					_Parent=Replace(_Parent.gameObject).transform;
				}
			}
			if(!EditorApplication.isPlaying)return;
			counter-=dt;
			if(counter<0){
				counter=120;
				Save();
			}
		}
		[MenuItem("TRNTH/PlayModeEditor")]static void ShowWindow(){
			var win=new HierarchyPlayModeEditor();
			win.Show();
			win.titleContent=new GUIContent("TRNTHPlayModeEditor");
			Instance=win;
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
		const string str_Replace="Replace";
		const string str_RecordSerialized="RecordSerialized";
		void OnGUI()
		{
			// EditorGUILayout.LabelField("保持這個介面顯示，Parent 底下的所有孩子的\n任何變動將會在 Play Mode 之後保留。");
			PropertyDrawer(Str_Parent,this);
			PropertyDrawer(str_foodData,this);
			AutoPipeline=GUILayout.Toggle(AutoPipeline,str_AutoPipeline);
			if(AutoPipeline)return;
			if(GUILayout.Button(str_Replace)){
				_Parent=Replace(_Parent.gameObject).transform;
			}
			if(GUILayout.Button(str_RecordSerialized)){
				RecordSerialized(_Parent.gameObject);
			}
		}
		const string TmpPrefabPath="Assets/_DungeonMealCore/Terrain/TmpPrefab.prefab";
		[MenuItem("TRNTH/PlayModeEditorSave %&s")]
		static void Save(){
			if(Instance)Instance.RecordSerialized();
		}
		void RecordSerialized(){
			if(_Parent==null)return;
			RecordSerialized(_Parent.gameObject);
		}
		protected virtual void RecordSerialized(GameObject gameObject){
			if(gameObject==null)return;
			var path=string.Format(TmpPrefabPath,Application.dataPath);
			PrefabUtility.CreatePrefab(path,gameObject);
		}

	}
}
