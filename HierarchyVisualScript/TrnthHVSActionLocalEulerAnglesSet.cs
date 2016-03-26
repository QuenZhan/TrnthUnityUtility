using UnityEngine;
using System.Collections;

public class TrnthHVSActionLocalEulerAnglesSet : TrnthHVSAction {
	public Transform target;
	public Vector3 angles;
	public Vector3 noise;
	protected override void _execute(){
		target.localEulerAngles=this.angles+noise*Random.value;
	}
}
