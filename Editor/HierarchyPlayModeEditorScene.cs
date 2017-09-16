using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TRNTH{

	public class HierarchyPlayModeEditorScene : HierarchyPlayModeEditor {
		// [MenuItem("TRNTH/PlayModeEditorScene")]
		static void Init(){
			var window=new HierarchyPlayModeEditorScene();
			window.Show();
		}

		const string TmpPrefabPath="Assets/_DungeonMealCore/Terrain/TmpScene.unity";

		protected override GameObject Replace(GameObject _Parent){
			// EditorSceneManager.LoadScene("TmpScene",LoadSceneMode.Additive);
			var activeScene=EditorSceneManager.GetActiveScene();
			var scene=EditorSceneManager.OpenScene(TmpPrefabPath,OpenSceneMode.Additive);
			foreach(var e in scene.GetRootGameObjects()){
				if(e.name!=_Parent.name)continue;
				DestroyImmediate(_Parent.gameObject);
				EditorSceneManager.MoveGameObjectToScene(e,activeScene);
				EditorSceneManager.CloseScene(scene,true);
				return e;
			}
			return null;
		}
		protected override void RecordSerialized(GameObject gameObject){
			 EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(),TmpPrefabPath,true);
		}
	}
}
