using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthFSM { 
	static public void transit(Transform state){
		foreach(Transform e in state.parent.Cast<Transform>().ToArray()){
			e.gameObject.SetActive(e==state);
		}
	}
}
