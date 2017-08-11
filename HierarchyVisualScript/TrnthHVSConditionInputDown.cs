using UnityEngine;
using System.Collections;

public class TrnthHVSConditionInputDown : TrnthHVSCondition {
	public KeyCode keyCode;
	void Update(){
		if(!Input.GetKeyDown(keyCode))return;
		send();
	}
}