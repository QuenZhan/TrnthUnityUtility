using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace TRNTH.Editor{
	public class ParentTo : EditorWindowBase {
		[SerializeField]Transform TheParent;
		const string StrTheParent="TheParent";		
		static void Initialize(){
			var window=new ParentTo();
			window.Show();
			Instance=window;
		}
		static ParentTo Instance;
		void OnGUI()
		{
			PropertyDrawer(StrTheParent,this);
		}
		[MenuItem("TRNTH/ParentTo %&p")]
		static void Do(){
			if(Instance!=null){
				Selection.activeGameObject.transform.SetParent(Instance.TheParent);
				var length=Selection.gameObjects.Length;
				for (int i = 0; i < length; i++)
				{
					Selection.gameObjects[i].transform.SetParent(Instance.TheParent);
				}
				return;
			}
			Initialize();
		}
	}

}
