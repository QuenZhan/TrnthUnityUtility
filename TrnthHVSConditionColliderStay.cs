using UnityEngine;
using System.Collections;
using System.Linq;
public class TrnthHVSConditionColliderStay : TrnthHVSConditionCollider {	
	void OnTriggerStay(Collider collider){
		if(debugLog)Debug.Log(name,collider);
		if(!includeTrigger)return;
		sendFilter(collider);
	}
	void OnCollisionStay(Collision collision){
		if(debugLog)Debug.Log(name,collision.collider);
		// _col=collision.collider;
		sendFilter(collision.collider);
	}
}
