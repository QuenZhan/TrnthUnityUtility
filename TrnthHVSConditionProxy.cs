using UnityEngine;
using System.Collections;

public class TrnthHVSConditionProxy : TrnthHVSCondition {
	public override string extraMsg{get{return"TrnthHVSConditionProxy";}}
	public TrnthHVSCondition target;
	void Awake(){
		target.callback+=send;
	}
}
