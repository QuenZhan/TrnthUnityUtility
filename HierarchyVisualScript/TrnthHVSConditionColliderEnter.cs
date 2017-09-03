using UnityEngine;
using System.Collections;
using System.Linq;
public class TrnthHVSConditionColliderEnter : TrnthHVSConditionCollider {	
	void OnTriggerEnter(Collider collider){
		if(!includeTrigger)return;
		sendFilter(collider);
	}
	void OnCollisionEnter(Collision collision){
		sendFilter(collision.collider);
	}
}
