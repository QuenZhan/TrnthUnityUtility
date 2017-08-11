using UnityEngine;
using System;
using System.Collections;

public class TrnthHVSConditionCcrHit : TrnthHVSCondition {
	public event Action<TrnthHVSConditionCcrHit,ControllerColliderHit> onCcrHit=delegate(TrnthHVSConditionCcrHit condition,ControllerColliderHit hit){};
    void OnControllerColliderHit(ControllerColliderHit hit) {
    	send();
    	onCcrHit(this,hit);
    }
}
