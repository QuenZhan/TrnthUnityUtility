using UnityEngine;
using System.Collections;

public class TrnthHVSConditionDespawned : TrnthHVSCondition {
	public override string extraMsg{get{return"TrnthHVSConditionDespawned";}}
	void OnDespawned(){
		send();
	}
}
