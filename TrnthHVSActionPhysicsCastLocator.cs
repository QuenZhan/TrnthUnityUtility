using UnityEngine;
using System.Collections;

public class TrnthHVSActionPhysicsCastLocator : TrnthHVSActionPhysicsCast {
	public Transform locator;
	protected override void _execute(){
		base._execute();
		if(!isHit)return;
		locator.position=hit.point;
	}
}
