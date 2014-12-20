using UnityEngine;
using System.Collections;

public class TrnthHVSActionFSMTransition : TrnthHVSAction {
	public TrnthFSMManager fsmManager;
	public GameObject state;
	public override string extraMsg{get{return "Transition";}}
	public override void execute(){
		base.execute();
		fsmManager.stateNow=state;
		fsmManager.update();
	}
}
