using UnityEngine;
using System.Collections;

public class TrnthHVSActionFSMTransition : TrnthHVSAction {
	public GameObject state;
	protected override void _execute(){
		TrnthFSM.transit(state.transform);
	}
}
