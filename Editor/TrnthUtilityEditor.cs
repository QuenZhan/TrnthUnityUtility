using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
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
    [MenuItem("TRNTH/IsolateUpward %&i")]
    static void isolateUpward(){
        var list=new List<Transform>();
        var now=Selection.activeGameObject.transform;
        TrnthFSM.transit(now);
        for(var i=0;i<10;i++){
            if(now==null||now.parent==null)break;
            list.Add(now);
            now=now.parent;
        }

        list.Reverse();
        foreach(var e in list){
            if(!e)continue;
            if(!e.gameObject.activeSelf)e.gameObject.SetActive(true);
            // TrnthFSM.transit(e);
        }
        // TrnthFSM.transit(Selection.activeGameObject);
        // ;
    }
    [MenuItem("TRNTH/cleanChildren")]
    static void cleanChildren(){
        TRNTH.U.cleanChildren(Selection.activeGameObject.transform);
    }
}