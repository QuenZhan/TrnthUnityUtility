using UnityEngine;
using System.Collections;

public class TrnthHVSActionFSMRendererTransit : TrnthHVSActionFSM {
	public Renderer rdr;
	protected override void _execute(){
		base._execute();
		fsm.transit(rdr);
	}
}
