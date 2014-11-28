using UnityEngine;
using System.Collections;

public class TrnthResetPosition : TrnthTriggerBase {
	public Transform target;
	public override void execute(){
		target.localPosition=Vector3.zero;
	}
}
