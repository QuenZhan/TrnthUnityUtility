using UnityEngine;
using System.Collections;
using TRNTH;

public class TrnthHVSActionRendererIsVisible : TrnthHVSAction {
	public Renderer Renderer;
	public TrnthHVSCondition onTrue;
	public TrnthHVSCondition onFalse;
	protected override void _execute(){
		if(Renderer.isVisible)send(onTrue);
		else send(onFalse);
	}
}
