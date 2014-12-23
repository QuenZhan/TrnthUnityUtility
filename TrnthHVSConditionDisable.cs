using UnityEngine;
using System.Collections;

public class TrnthHVSConditionDisable : TrnthHVSCondition {
	void OnDisable(){
		execute();
	}
}
