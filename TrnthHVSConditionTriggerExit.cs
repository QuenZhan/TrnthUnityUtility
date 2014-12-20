using UnityEngine;
using System.Collections;

public class TrnthHVSConditionTriggerExit : TrnthHVSCondition {
	void OnTriggerExit(){
		execute();
	}
}
