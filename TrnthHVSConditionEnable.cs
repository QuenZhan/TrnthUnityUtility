using UnityEngine;
using System.Collections;

public class TrnthHVSConditionEnable : TrnthHVSCondition {
	void OnEnable(){
		// if(_afterAwake&&notBeforeAwake)send();
		// if(!notBeforeAwake||_afterAwake)send();
		send();
	}
}
