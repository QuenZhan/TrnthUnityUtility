using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace TRNTH{
	public class EditorWindowBase : UnityEditor.EditorWindow {
		protected void PropertyDrawer(string propertyName){
			PropertyDrawer(propertyName,this);
		}
		protected void PropertyDrawer<T>(string propertyName,T self) where T:ScriptableObject{
			ScriptableObject target = self;
			SerializedObject so = new SerializedObject(target);
			SerializedProperty stringsProperty = so.FindProperty(propertyName);
			if (stringsProperty == null)
				return;
			EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
			so.ApplyModifiedProperties(); // Remember to apply modified properties
		}
	}

}
