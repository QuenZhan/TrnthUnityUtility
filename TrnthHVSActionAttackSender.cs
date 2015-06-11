using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthHVSActionAttackSender : TrnthHVSAction ,ITrnthAttack{
	public TrnthHVSActionPhysicsCast pc;
	public TrnthHVSConditionCollider conditionCollider;
	public TrnthHVSCondition cOnReact;
	public Transform _worldOrigin;
	public float _damage=30;
	public float _knockback;
	public bool _showDamage=false;
	public TrnthHVSActionSpawn[] attachments;

	public event System.Action<TrnthHVSActionAttackSender,TrnthHVSConditionAttackReceiver> onReact=delegate{};
	public virtual float damage{get{
		return 1+Random.value*(_damage);
	}}
	public float knockback{get{
		return _knockback;
	}}
	public Vector3 worldOrigin{get{
		return _worldOrigin.position;
	}}
	public bool showDamage{get{
		return _showDamage;
	}}

	protected override void _execute(){
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
		this.send(cOnReact);
		onReact(this,receiver);
	}
}
