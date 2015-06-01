using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthHVSActionAttackSender : TrnthHVSAction {
	public TrnthHVSActionPhysicsCast pc;
	public TrnthHVSConditionCollider conditionCollider;
	public TrnthAttack attack;
	public TrnthHVSActionSpawn[] attachments;
	protected override void _execute(){
		base._execute();
		// if(proxy)pc=proxy.physicsCast;
		var colliders=new Collider[0];
		if(pc)colliders=pc.colliders;
		if(conditionCollider)colliders=new Collider[]{conditionCollider.col};
		foreach(Collider e in colliders){
			var dr=e.GetComponent<TrnthHVSConditionAttackReceiver>();
			// if(!dr)dr=GetComponent<TrnthHVSConditionAttackReceiver>();
			if(!dr)continue;
			dr.hurtWith(attack,pc);
			foreach(var spawner in attachments){
				spawner.execute();
				var constraint=spawner.spawned.gameObject.AddComponent<TrnthConstraintPosition>();
				constraint.position=e.transform;
			}
		}
	}
	// Collider[] colliders=new Collider[0];
}
