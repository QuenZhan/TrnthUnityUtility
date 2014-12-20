using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider))]
public class TrnthHVSConditionColliderEnter : TrnthHVSCondition {
	public bool includeTrigger=true;
	void OnTriggerEnter(){
		if(includeTrigger)execute();
	}
	void OnCollisionEnter(){
		execute();	
	}
}
