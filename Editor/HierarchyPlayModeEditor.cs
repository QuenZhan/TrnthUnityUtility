using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
namespace TRNTH{
	public class HierarchyPlayModeEditor : EditorWindowBase {
		[MenuItem("TRNTH/PlayModeEditor")]
		static void ShowWindow(){
			var win=new HierarchyPlayModeEditor();
			win.Show();
		}
		void OnSelectionChange(){
		}
		// void R
		void OnHierarchyChange(){
			if(_Parent==null && EditorApplication.isPlaying){
				EditorApplication.isPlaying=false;
				GUIContent gUIContent=new GUIContent("PlayModeEditor._Parent==null");
				ShowNotification(gUIContent);
			}
		}
		void Replace(){
			var prefab=(GameObject)AssetDatabase.LoadAssetAtPath(TmpPrefabPath,typeof(GameObject));
			var newOne=PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			newOne.name=_Parent.gameObject.name;
			DestroyImmediate(_Parent.gameObject);
			PrefabUtility.DisconnectPrefabInstance(newOne);
			_Parent=newOne.transform;
		}
		void Apply(GameObject gameObject){
			var to=new SerializedObject(gameObject.transform);
			var from=_dicSerialized[gameObject];
			var property=from.GetIterator();
			while(property.Next(true)){
				to.CopyFromSerializedProperty(property);
			}
			to.ApplyModifiedPropertiesWithoutUndo();
			_dicSerialized.Remove(gameObject);
			_Selected.Remove(gameObject);
		}
		void OnFocus(){
			EditorApplication.playmodeStateChanged-=StateChanged;
			EditorApplication.playmodeStateChanged+=StateChanged;
		}
		bool AutoPipeline=true;
		private void StateChanged()
		{
			if(!AutoPipeline)return;
			if (!EditorApplication.isPlayingOrWillChangePlaymode &&
				EditorApplication.isPlaying ) 
			{
				RecordSerialized();
			}
			if(EditorApplication.isPlaying){
				return;
			}
			Replace();
		}
		bool _playing;

		[SerializeField]Transform _Parent;
		[SerializeField]List<GameObject> _Selected;
		Dictionary<GameObject,SerializedObject> _dicSerialized=new Dictionary<GameObject, SerializedObject>();
		// void PropertyDrawer(string propertyName){
		// 	ScriptableObject target = this;
		// 	SerializedObject so = new SerializedObject(target);
		// 	SerializedProperty stringsProperty = so.FindProperty(propertyName);
		// 	EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
		// 	so.ApplyModifiedProperties(); // Remember to apply modified properties
		// }
		void OnGUI()
		{
			EditorGUILayout.LabelField("目標的所有孩子任何變動將會在 Play Mode 保留");
			PropertyDrawer("_Parent",this);
			AutoPipeline=GUILayout.Toggle(AutoPipeline,"AutoPipeline");
			if(AutoPipeline)return;
			// EditorGUILayout.LabelField(string.Format("Recording:{0}",Application.isPlaying));
			PropertyDrawer("_Selected",this);
			if(GUILayout.Button("Replace")){
				Replace();
			}
			if(GUILayout.Button("RecordSerialized")){
				RecordSerialized(_Parent.gameObject);
			}
		}
		const string TmpPrefabPath="Assets/_DungeonMealCore/Terrain/TmpPrefab.prefab";
		void RecordSerialized(){
			RecordSerialized(_Parent.gameObject);
		}

		void RecordSerialized(GameObject gameObject){
			var path=string.Format(TmpPrefabPath,Application.dataPath);
			PrefabUtility.CreatePrefab(path,gameObject);
		}

	}
}
