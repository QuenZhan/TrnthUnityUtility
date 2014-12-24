using UnityEngine;
using System.Collections;

public class TrnthHVSActionFSMRendererTransit : TrnthHVSAction {
	public TrnthFSM fsmManger;
	public Renderer renderer;
	protected override void _execute(){
		base._execute();
		fsmManger.transit(renderer);
	}
}
