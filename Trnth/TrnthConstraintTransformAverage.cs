using UnityEngine;
using System.Collections;

public class TrnthTransformAverageConstraint : TrnthMonoBehaviour {
	public Transform[] targets;
	void Update(){
		var vec=Vector3.zero;
		foreach(Transform e in targets){
			vec+=e.position;
		}
		Position=vec/targets.Length;
	}
}
