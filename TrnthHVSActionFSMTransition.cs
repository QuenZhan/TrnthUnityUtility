using UnityEngine;
using System.Collections;

public class TrnthHVSActionFSMTransition : TrnthHVSAction {
	// public TrnthFSMManager fsmManager;
	public GameObject state;
	public override string extraMsg{get{return "Transition";}}
	protected override void _execute(){
		base._execute();
		TrnthFSM.transit(state.transform);
		// var fsmManager=state.transform.parent.GetComponent<TrnthFSMManager>();
		// fsmManager.stateNow=state;
		// fsmManager.update();
	}
}
