using UnityEngine;
using System.Collections;

public class TrnthHVSConditionCollider : TrnthHVSCondition {
	public delegate void CallbackCollider(Collider collider);
	public event CallbackCollider callbackCollider;
	public void execute(Collider collider){
		execute();
		if(callbackCollider!=null)callbackCollider(collider);
	}
}
