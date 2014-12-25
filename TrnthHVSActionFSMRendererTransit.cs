using UnityEngine;
using System.Collections;

public class TrnthHVSActionFSMRendererTransit : TrnthHVSAction {
	public TrnthFSM fsmManger;
	public Renderer rdr;
	protected override void _execute(){
		base._execute();
		fsmManger.transit(rdr);
	}
}
