using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthFSM { 	
	static public void transit(GameObject state){
		transit(state.transform);
	}
	static public void transit(Component comp){
		var state=comp.transform;
		foreach(Transform e in state.parent.Cast<Transform>().ToArray()){
			e.gameObject.SetActive(e==state);
		}
	}
	static public void clear(Component comp){
		foreach(Transform e in comp.transform.parent){
			e.gameObject.SetActive(false);
		}
	}
}
