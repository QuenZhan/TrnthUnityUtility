using UnityEngine;
using UnityEditor;
namespace TRNTH{
[CustomEditor(typeof(Gardener))]
public class Brush : Editor {
	void OnSceneGUI(){
		HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
		if(Event.current.type == EventType.MouseDown){
			// hit as RaycastHit
			if(Physics.Raycast(HandleUtility.GUIPointToWorldRay(Event.current.mousePosition)))
				Debug.Log("Hit");
				// hit.transform.position.y += 5
		}
	}
}
}