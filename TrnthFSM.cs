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
		instance.checkDelta(state);
	}
	static public void clear(Component comp){
		foreach(Transform e in comp.transform.parent){
			e.gameObject.SetActive(false);
		}
	}
	List<Data> parents=new List<Data>();
	internal void checkDelta(Transform child){
		StartCoroutine(_checkDelta(child));
	}
	IEnumerator _checkDelta(Transform child) {
		var parent=child.parent;
		foreach(var data in parents.ToArray()){
			if(data.parent!=parent)continue;
			var str=System.String.Format("TrnthFSM delta: {0}/{1} >> {2}/{3}",data.parent.name,data.child.name,parent.name,child.name);
			Debug.LogWarning(str,child);
		}
		var _data=new Data(){time=Time.time,parent=parent,child=child};
		parents.Add(_data);
        yield return new WaitForSeconds(0.1f);
        parents.Remove(_data);
    }
    class Data{
    	public float time;
    	public Transform parent;
    	public Transform child;
    }
}
