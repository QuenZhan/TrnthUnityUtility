using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthHVSActionAttackSender : TrnthHVSAction {
	public TrnthHVSActionPhysicsCast pc;
	public TrnthHVSConditionCollider conditionCollider;
	public TrnthHVSCondition conditionReact;
	public Transform direction;
	public float damageBase=30;
	public float knockback;
	public bool showDamage=false;
	public TrnthHVSActionSpawn[] attachments;

	public event System.Action<TrnthHVSActionAttackSender,TrnthHVSConditionAttackReceiver> onReact=delegate{};
	public virtual float damage{get{
		return 1+Random.value*(damageBase);
	}}
	protected override void _execute(){
		base._execute();
		var colliders=new Collider[0];
		if(pc)colliders=pc.colliders;
		if(conditionCollider)colliders=new Collider[]{conditionCollider.col};
		foreach(Collider e in colliders){
			attach(e.transform);
			var dr=e.GetComponent<TrnthHVSConditionAttackReceiver>();
			if(!dr)continue;
			dr.hurtWith(this,react);
		}
	}
	protected virtual void attach(Transform tra){
		foreach(var spawner in attachments){
			spawner.transform.position=tra.position;
			spawner.execute();
		}
	}
	void react(TrnthHVSConditionAttackReceiver receiver){
		this.send(conditionReact);
		onReact(this,receiver);
	}
}
