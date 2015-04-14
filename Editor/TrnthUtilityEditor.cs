using UnityEngine;
using UnityEditor;
public class TrnthUtilityEditor : Editor {
	[MenuItem("TRNTH/DeletePlayerPrefs %&d")]
    private static void deletePrefs() {
    	PlayerPrefs.DeleteAll();
    	Debug.Log("PlayerPrefs.DeleteAll() ");
    }
}