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
		var colliders=new Collider[0];
		if(pc)colliders=pc.colliders;
		if(conditionCollider)colliders=new Collider[]{conditionCollider.col};
		foreach(Collider e in colliders){
			attack.attach(e.transform);
			var dr=e.GetComponent<TrnthHVSConditionAttackReceiver>();
			if(!dr)continue;
			dr.hurtWith(attack.report,attack);
		}
	}
}