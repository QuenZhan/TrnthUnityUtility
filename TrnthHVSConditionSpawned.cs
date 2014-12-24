using UnityEngine;
using System.Collections;

public class TrnthHVSConditionSpawned : TrnthHVSCondition {
	public override string extraMsg{get{return"TrnthHVSConditionSpawned";}}

	void OnSpawned(){
		send();
	}
}
