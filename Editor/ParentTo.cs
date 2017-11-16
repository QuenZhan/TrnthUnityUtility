using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace TRNTH.Editor{
	public class ParentTo : EditorWindowBase {
		[SerializeField]Transform TheParent;
		[SerializeField]Transform[] Candidates;
		[SerializeField]Color _color;
		const string StrTheParent="TheParent";
		const string StrCandidates="Candidates";
		const string Str_color="_color";
		void OnGUI()
		{
			PropertyDrawer(StrTheParent,this);
			PropertyDrawer(StrCandidates,this);
			PropertyDrawer(Str_color,this);
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
		[MenuItem("TRNTH/ColorIt &c")]
		static void Color(){
			var Instance=GetWindow<ParentTo>();
			var length=Selection.gameObjects.Length;
			for (int i = 0; i < length; i++)
			{
				var spriteRender=Selection.gameObjects[i].GetComponent<SpriteRenderer>();
				if(!spriteRender)continue;
				spriteRender.color=Instance._color;
			}
		}
	}

}
