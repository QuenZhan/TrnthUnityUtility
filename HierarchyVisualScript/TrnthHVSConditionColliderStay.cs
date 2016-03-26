using UnityEngine;
using System.Collections;
using System.Linq;
public class TrnthHVSConditionColliderStay : TrnthHVSConditionCollider {	
	void OnTriggerStay(Collider collider){
		if(!includeTrigger)return;
		sendFilter(collider);
	}
	void OnCollisionStay(Collision collision){
		sendFilter(collision.collider);
	}
}
