using UnityEngine;
using System.Collections;

public class TrnthFSMManagerApply : TrnthTriggerBase {
	// public TrnthFSMManager fsmManager;
	public GameObject state;
	public override void execute(){
		if(log)Debug.Log(name);
		var fsmManager=state.transform.parent.GetComponent<TrnthFSMManager>();
		fsmManager.stateNow=state;
		fsmManager.update();
	}
}
