using UnityEngine;
using System.Collections;

public class TrnthTransformAverageConstraint : TRNTH.MonoBehaviour {
	public Transform[] targets;
	void Update(){
		var vec=Vector3.zero;
		foreach(Transform e in targets){
			vec+=e.position;
		}
		pos=vec/targets.Length;
	}
}
