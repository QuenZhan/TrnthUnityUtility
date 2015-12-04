using UnityEngine;
using System.Collections;

public class TrnthHVSActionConditionSend : TrnthHVSAction {
	public TrnthHVSCondition condition;
	public string find;
	protected override void _execute(){
		base._execute();
		if(!condition){
			Debug.LogError("!condition",this);
			// var go=GameObject.Find(find);
			// condition=go.GetComponent<TrnthHVSCondition>();
		}
		condition.send();
	}
}
