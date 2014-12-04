using UnityEngine;
using System.Collections;

public class TrnthFSMManagerApply : TrnthTriggerBase {
	public TrnthFSMManager fsmManager;
	public GameObject state;
	public override void execute(){
		if(log)Debug.Log(name);
		fsmManager.stateNow=state;
		fsmManager.update();
	}
}
