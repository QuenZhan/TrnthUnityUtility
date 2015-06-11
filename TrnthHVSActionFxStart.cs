using UnityEngine;
using System.Collections;

public class TrnthHVSActionFxStart : TrnthHVSAction {
	public TrnthFx fx;
	protected override void _execute(){
		fx.start();
	}
}
