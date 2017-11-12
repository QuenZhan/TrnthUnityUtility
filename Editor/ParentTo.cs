using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace TRNTH.Editor{
	public class ParentTo : EditorWindowBase {
		[SerializeField]Transform TheParent;
		[SerializeField]Transform[] Candidates;
		const string StrTheParent="TheParent";
		const string StrCandidates="Candidates";		
		// static void Initialize(){
		// 	var window=new ParentTo();
		// 	window.Show();
		// }
		// static ParentTo Instance;
		void OnGUI()
		{
			PropertyDrawer(StrTheParent,this);
			PropertyDrawer(StrCandidates,this);
		}
		[MenuItem("TRNTH/ParentTo &p")]
		static void Do(){
			var Instance=GetWindow<ParentTo>();
			Selection.activeGameObject.transform.SetParent(Instance.TheParent);
			var length=Selection.gameObjects.Length;
			for (int i = 0; i < length; i++)
			{
				Selection.gameObjects[i].transform.SetParent(Instance.TheParent);
			}
		}
		// const string str_mark="[PARENT]";
		// [MenuItem("TRNTH/Mark as Parent")]
		// static void Mark(){
		// 	var originName=Selection.activeGameObject.name;
		// 	var modName=originName.Replace(str_mark,string.Empty)+str_mark;
		// 	Selection.activeGameObject.name=modName;
		// }
	}

}
