using UnityEngine;
using System.Collections;
public class TrnthHVSConditionClick : TrnthHVSCondition {
	public override string extraMsg{get{return"Click";}}
	void OnClick(){
		send();
	}
}
