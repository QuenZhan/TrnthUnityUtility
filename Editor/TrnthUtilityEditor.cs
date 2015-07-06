using UnityEngine;
using UnityEditor;
public class TrnthUtilityEditor : Editor {
	[MenuItem("TRNTH/DeletePlayerPrefs")]
    private static void deletePrefs() {
    	PlayerPrefs.DeleteAll();
    	Debug.Log("PlayerPrefs.DeleteAll() ");
    }
    [MenuItem("TRNTH/Isolate %i")]
    static void isolate(){
    	TrnthFSM.transit(Selection.activeGameObject);
    	// ;
    }
}