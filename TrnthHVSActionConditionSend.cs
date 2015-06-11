using UnityEngine;
using System.Collections;

public class TrnthHVSActionConditionSend : TrnthHVSAction {
	public TrnthHVSCondition condition;
	public string find;
	protected override void _execute(){
		if(!condition){
			var go=GameObject.Find(find);
			condition=go.GetComponent<TrnthHVSCondition>();
		}
		condition.send();
	}
}
