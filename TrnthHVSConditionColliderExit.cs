using UnityEngine;
using System.Collections;
using System.Linq;
public class TrnthHVSConditionColliderExit : TrnthHVSConditionCollider {	
	void OnTriggerExit(Collider collider){
		if(!includeTrigger)return;
		sendFilter(collider);
	}
	void OnCollisionExit(Collision collision){
		sendFilter(collision.collider);
	}
}
