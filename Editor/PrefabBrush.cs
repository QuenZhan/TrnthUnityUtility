using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace TRNTH{

	public class PrefabBrush : EditorWindowBase {
		[MenuItem("TRNTH/PrefabBrush")]
		static void Init(){
			var window=new PrefabBrush();
			window.Show();
		}
		void Update()
		{
			if(_camera==null)return;
			var ray=Utility.MousePositionRay(_camera);
			var number=Physics.RaycastNonAlloc(ray,_results,10,-1);
			if(number>0){
				Debug.Log(_results[0].collider.name);
			}
		}
		RaycastHit[] _results;
		[SerializeField]Camera _camera;
		[SerializeField]GameObject _Prefab;
		void OnGUI()
		{
			GUILayout.Label("地形繪製");
			PropertyDrawer("_Prefab");
			PropertyDrawer("_camera");
		}
	}
}
