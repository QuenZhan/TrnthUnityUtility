using UnityEngine;
using System.Collections;

public class TrnthHVSActionEnable : TrnthHVSAction {
	public TrnthHVSActionActivate.Mode mode;
	public Behaviour behaviour;
	protected override void _execute(){
		// var yes=true;
		switch(mode){
		case TrnthHVSActionActivate.Mode.on		:behaviour.enabled=true;break;
		case TrnthHVSActionActivate.Mode.off	:behaviour.enabled=false;break;
		case TrnthHVSActionActivate.Mode.toggle	:behaviour.enabled=!behaviour.enabled;break;
		case TrnthHVSActionActivate.Mode.trigger:
			behaviour.enabled=true;
			behaviour.enabled=false;
			break;
		}
	}
}
