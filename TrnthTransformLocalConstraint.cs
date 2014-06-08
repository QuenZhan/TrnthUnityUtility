using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthTransformLocalConstraint : TRNTH.MonoBehaviour {
	public Transform target;
	void Update () {
		tra.localPosition=target.localPosition;
	
	}
}
