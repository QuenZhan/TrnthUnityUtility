using UnityEngine;
using System.Collections;

public class TrnthFSMPhysicsCast : TrnthFSM {
	public TrnthHVSActionPhysicsCast physicsCast {get;private set;}
	public override bool transit(Component state){
		physicsCast=state as TrnthHVSActionPhysicsCast;
		if(!physicsCast)return false;
		return base.transit(physicsCast);
	}

}
