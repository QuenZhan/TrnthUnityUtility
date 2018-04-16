using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace TRNTH{
	public class EditorUtility  {
		public static void GetAllAssets<T>(IList<T> toHere) where T:class{
			#if UNITY_EDITOR
			var type=typeof(T);
			var guids= UnityEditor.AssetDatabase.FindAssets(string.Format("t:{0}",type.Name));
			toHere.Clear();
			foreach(var guid in guids){
				var path=UnityEditor.AssetDatabase.GUIDToAssetPath (guid);
				var recipe=UnityEditor.AssetDatabase.LoadAssetAtPath(path,type) as T;
				toHere.Add(recipe);
			}
			#endif

		}
		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void GetAllAssets<T>(MutableNonAllocList<T> toHere) where T:class{
						#if UNITY_EDITOR

			var type=typeof(T);
			var guids= UnityEditor.AssetDatabase.FindAssets(string.Format("t:{0}",type.Name));
			toHere.Clear();
			foreach(var guid in guids){
				var path=UnityEditor.AssetDatabase.GUIDToAssetPath (guid);
				var recipe=UnityEditor.AssetDatabase.LoadAssetAtPath(path,type) as T;
				toHere.Add(recipe);
			}
						#endif

		}
		public static void GetAllObjectsInScene<T>(List<T> objectsInScene) where T:UnityEngine.Object
		{
			#if UNITY_EDITOR
			objectsInScene.Clear();
			foreach (T go in Resources.FindObjectsOfTypeAll<T>() )
			{
				if (go.hideFlags != HideFlags.None){
					continue;
				}

				if (PrefabUtility.GetPrefabType(go) == PrefabType.Prefab 
				|| PrefabUtility.GetPrefabType(go) == PrefabType.ModelPrefab){
					continue;

				}

				objectsInScene.Add(go);
			}
			#endif
		}
	}

}
