using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthFSM:MonoBehaviour {
	static TrnthFSM instance;
	static public void transit(GameObject state){
		transit(state.transform);
	}
	static public void transit(Component comp){
		var state=comp.transform;
		var parent=comp.transform.parent;
		foreach(Transform e in parent){
			e.gameObject.SetActive(e==state);
		}
		if(!instance){
			instance=(new GameObject("TrnthFSM")).AddComponent<TrnthFSM>();
		}
		instance.checkDelta(parent,state);
	}
	static public void clear(Component comp){
		foreach(Transform e in comp.transform.parent){
			e.gameObject.SetActive(false);
		}
	}
	Dictionary<Transform,Data> parents=new Dictionary<Transform,Data>();
	internal void checkDelta(Transform parent,Transform child){
		StartCoroutine(_checkDelta(parent,child));
	}
	IEnumerator _checkDelta(Transform parent,Transform child) {
		if(parents.ContainsKey(parent)){
			var data=parents[parent];
			var str=String.Format("TrnthFSM delta: {0}/{1} >> {2}/{3}",data.parent.name,data.child.name,parent.name,child.name);
			Debug.LogWarning(str,child);
		}
		parents.Add(parent);
        yield return new WaitForSeconds(0.1f);
        parents.Remove(parent);
    }
    class Data{
    	public float time;
    	public Transform parent;
    	public Transform child;
    }
}
