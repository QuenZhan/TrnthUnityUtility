using UnityEngine;
using System.Collections;

public class TrnthHVSActionParent : TrnthHVSAction {
	public Transform target;
	public Transform parentTo;
	public bool keepOffset;
	protected override void _execute(){
		target.parent=parentTo;
		if(!keepOffset){
			target.localPosition=Vector3.zero;
			target.localEulerAngles=Vector3.zero;
		}
	}
}