using UnityEngine;
using System.Collections;

public class TrnthHVSActionFSMTransformTransit : TrnthHVSAction {
	public Transform state;
	public override string extraMsg{get{return "FSMTransformTransition";}}
	protected override void _execute(){
		base._execute();
		var fsmManager=state.parent.GetComponent<TrnthFSMTransform>();
		fsmManager.transit(state);
	}
}
