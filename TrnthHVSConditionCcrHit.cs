using UnityEngine;
using System.Collections;

public class TrnthHVSConditionCcrHit : TrnthHVSCondition {
    void OnControllerColliderHit(ControllerColliderHit hit) {
    	send();
    }
}
