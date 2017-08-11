using UnityEngine;
using System.Collections;

public class TrnthHVSConditionRendererInvisiable : TrnthHVSCondition {
	void OnBecameInvisible(){
		send();
	}
}
