using UnityEngine;
using System.Collections;

public class TrnthHVSActionConditionSend : TrnthHVSAction {
	public TrnthHVSCondition condition;
	[HideInInspector]public string find;
	protected override void _execute(){
		base._execute();
		if(!condition){
			Debug.LogError("!condition",this);
		}
		condition.send();
	}
}
