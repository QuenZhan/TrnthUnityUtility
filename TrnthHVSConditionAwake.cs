using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAwake : TrnthHVSCondition {
	// public bool sendMessage;
	public override string extraMsg{get{return"Awake";}}
	void Awake(){
		send();
		// log();
		// gameObject.SendMessage("execute");
	}
}
