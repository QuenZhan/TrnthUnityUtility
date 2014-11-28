using UnityEngine;
using System.Collections;

public class TrnthFSMManagerApply : TrnthTriggerBase {
	public TrnthFSMManager fsmManager;
	public GameObject state;
	public override void execute(){
		// Debgu.Log("dsf");
		fsmManager.stateNow=state;
		fsmManager.update();
	}
}
