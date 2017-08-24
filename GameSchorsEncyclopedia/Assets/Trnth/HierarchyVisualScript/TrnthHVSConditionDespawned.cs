using UnityEngine;
using System.Collections;

public class TrnthHVSConditionDespawned : TrnthHVSCondition {
	void OnDespawned(){
		send();
	}
}
