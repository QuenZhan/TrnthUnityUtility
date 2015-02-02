using UnityEngine;
using System.Collections;

public class TrnthHVSConditionCollider : TrnthHVSCondition {
	public delegate void CallbackCollider(Collider collider);
	public event CallbackCollider callbackCollider;
	public string[] include;
	public void execute(Collider collider){
		send();
		if(callbackCollider!=null)callbackCollider(collider);
	}
}
