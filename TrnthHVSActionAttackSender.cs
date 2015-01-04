using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthHVSActionAttackSender : TrnthHVSAction {
	public TrnthHVSActionPhysicsCast pc;
	public TrnthFSMPhysicsCast proxy;
	public TrnthAttack attack;
	// public int damage;
	protected override void _execute(){
		base._execute();
		if(proxy)pc=proxy.physicsCast;
		if(pc&&pc.colliders!=null)colliders=pc.colliders;
		foreach(Collider e in colliders){
			var dr=e.GetComponent<TrnthAttackReceiver>();
			if(!dr)continue;
			dr.hurtWith(attack);
		}
	}
	Collider[] colliders=new Collider[0];
	void OnTriggerEnter(Collider collider){
		// Debug.Log(collider.name);
		colliders=new Collider[]{collider};
		execute();
	}
	void OnCollisionEnter(Collision collision){
		colliders=new Collider[]{collision.collider};
		execute();
	}
}
