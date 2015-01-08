using UnityEngine;
using System.Collections;

public class TrnthHVSActionFSMPhysicsCastTransit : TrnthHVSActionFSM {
	public TrnthHVSActionPhysicsCast physicsCast;
	protected override void _execute(){
		base._execute();
		fsm.transit(physicsCast);
	}
}