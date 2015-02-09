using UnityEngine;
using System.Collections;
using System.Linq;
public class TrnthHVSConditionColliderEnter : TrnthHVSConditionCollider {	
	void OnTriggerEnter(Collider collider){
		if(debugLog)Debug.Log(name,collider);
		if(!includeTrigger)return;
		// _col=collider;
		sendFilter(collider);
	}
	void OnCollisionEnter(Collision collision){
		if(debugLog)Debug.Log(name,collision.collider);
		// _col=collision.collider;
		sendFilter(collision.collider);
	}
}
