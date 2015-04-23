using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthTransformLocalConstraint : TrnthMonoBehaviour {
	public Transform target;
	void Update () {
		tra.localPosition=target.localPosition;
	
	}
}
