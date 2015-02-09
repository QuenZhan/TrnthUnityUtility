using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthHVSActionAttackSender : TrnthHVSAction {
	public TrnthHVSActionPhysicsCast pc;
	public TrnthHVSConditionCollider conditionCollider;
	public TrnthAttack attack;
	protected override void _execute(){
		base._execute();
		// if(proxy)pc=proxy.physicsCast;
		if(pc&&pc.colliders!=null)colliders=pc.colliders;
		if(conditionCollider)colliders=new Collider[]{conditionCollider.col};
		foreach(Collider e in colliders){
			var dr=e.GetComponent<TrnthAttackReceiver>();
			if(!dr)continue;
			dr.hurtWith(attack,pc);
		}
	}
	Collider[] colliders=new Collider[0];
}
