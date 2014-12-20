using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider))]
public class TrnthHVSConditionTriggerEnter : TrnthHVSCondition {
	void OnTriggerEnter(){
		execute();
	}
}
