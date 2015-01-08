using UnityEngine;
using System.Collections;

public class TrnthHVSActionFSMComponentTransit : TrnthHVSActionFSM {
	public Component component;
	protected override void _execute(){
		fsm.transit(component);
	}
}
