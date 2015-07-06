using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class TrnthHVSActionAttackSender : TrnthHVSAction ,ITrnthAttackOffensive{
	[SerializeField] Transform _forceDirection;
	[SerializeField] float _forceValue;
	[SerializeField] bool _showDamage=false;
	[SerializeField] float _damage=30;
	[SerializeField] float _penetration=0;
	[SerializeField] float _criticalStikeChance=0.1f;
	[SerializeField] float _criticalStikeScale=2;
	[SerializeField] TrnthHVSAction[] attachments;
	[SerializeField] TrnthHVSCondition cOnReact;

	public virtual float damage{get{
		return 1+Random.value*(_damage);
	}}
	public Vector3 force{get{
		return _forceDirection.TransformDirection(Vector3.forward)*_forceValue;
	}}
	public bool showDamage{get{
		return _showDamage;
	}}
	public float penetration{get{return _penetration;}}
	public float criticalStikeChance{get{return _criticalStikeChance;}}
	public float criticalStikeScale{get{return _criticalStikeScale;}}


	protected override void _execute(){
		foreach(Collider e in colliders){
			attach(e.transform);
			var dr=e.GetComponent<TrnthHVSConditionAttackReceiver>();
			if(!dr)continue;
			dr.hurtWith(this);
			this.send(cOnReact);

		}
	}
	protected virtual void attach(Transform tra){
		foreach(var spawner in attachments){
			spawner.transform.position=tra.position;
			spawner.execute();
		}
	}
	protected abstract Collider[] colliders{get;}
	void react(TrnthHVSConditionAttackReceiver receiver){
		this.send(cOnReact);
		// onReact(this,receiver);
	}
}
