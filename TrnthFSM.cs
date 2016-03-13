using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthFSM {
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
		#if UNITY_EDITOR
			if(instance==null){
				instance=(new TrnthFSM());
			}
			instance.checkDelta(state);
		#endif
	}
	static public void clear(Component comp){
		foreach(Transform e in comp.transform.parent){
			e.gameObject.SetActive(false);
		}
	}
	internal void checkDelta(Transform child){
		var parent=child.parent;
		foreach(var data in parents.ToArray()){
			if(Time.time-data.time>MINTIME){
				parents.Remove(data);
				continue;
				// continue;
			}
			if(data.parent!=parent)continue;
			// Debug.LogWarning(System.String.Format("TrnthFSM delta time :{4} . {0}/{1} -> {2}/{3}",data.parent.name,data.child.name,parent.name,child.name,Time.time-data.time),child);
		}
		var _data=new Data(){time=Time.time,parent=parent,child=child};
		parents.Add(_data);
	}
	const float MINTIME=0.1f;
	List<Data> parents=new List<Data>();
    class Data{
    	public float time;
    	public Transform parent;
    	public Transform child;
    }
}
