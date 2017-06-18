using UnityEngine;
using System.Collections;

public class TrnthHVSConditionEnable : TrnthHVSCondition {
	public bool cancelInvokeOnDisable=true;
	void OnEnable(){
		send();
	}
	void OnDisable(){
		if(cancelInvokeOnDisable)CancelInvoke();
	}
}
