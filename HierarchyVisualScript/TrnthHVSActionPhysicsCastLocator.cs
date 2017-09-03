using UnityEngine;
using System.Collections;
using System.Linq;
public class TrnthHVSActionPhysicsCastLocator : TrnthHVSActionPhysicsCast {
	public Transform locator;
	protected override void _execute(){
		base._execute();
		if(colliders.Length<1)return;
		var collider=colliders.First();
		// if(!isHit)return;
		locator.position=collider.transform.position;
	}
}
