using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthHVSActionAttackSender : TrnthHVSAction {
	public TrnthHVSActionPhysicsCast pc;
	public TrnthHVSConditionCollider conditionCollider;
	public TrnthAttack attack;
	protected override void _execute(){
		base._execute();
		var colliders=new Collider[0];
		if(pc)colliders=pc.colliders;
		if(conditionCollider){
			colliders=new Collider[]{conditionCollider.col};
		}
		foreach(Collider e in colliders){
			if(!e)continue;
			attack.attach(e.transform);
			var dr=e.GetComponent<TrnthHVSConditionAttackReceiver>();
			if(!dr)continue;
			dr.hurtWith(attack.report,attack);
		}
	}
	protected void OnEnable(){
		var dsAttack=(attack as DSMAttack);
		if(!dsAttack
			||dsAttack.shell==null
			||dsAttack.shell.member==null
			)return;
		if(pc)pc.layermask=1<<dsAttack.shell.member.enemy.layerReciever;
		if(conditionCollider)conditionCollider.gameObject.layer=dsAttack.shell.member.ally.layerCaster;
	}
}