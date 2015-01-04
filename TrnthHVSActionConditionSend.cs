using UnityEngine;
using System.Collections;

public class TrnthHVSActionConditionSend : TrnthHVSAction {
	public TrnthHVSCondition condition;
	protected override void _execute(){
		base._execute();
		condition.send();
	}
}
