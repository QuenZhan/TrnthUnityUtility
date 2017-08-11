using UnityEngine;
using System.Collections;
using TRNTH;

public class TrnthHVSActionRendererIsVisible : TrnthHVSAction {
	public new Renderer renderer;
	public TrnthHVSCondition onTrue;
	public TrnthHVSCondition onFalse;
	protected override void _execute(){
		if(renderer.isVisible)send(onTrue);
		else send(onFalse);
	}
}
