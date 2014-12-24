using UnityEngine;
using System.Collections;

public class TrnthHVSConditionRendererVisiable : TrnthHVSCondition {
	void OnBecameVisible(){
		send();
	}
}
