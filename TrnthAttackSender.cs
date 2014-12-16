using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthAttackSender : MonoBehaviour {
	public TrnthPhysicsCast pc;
	public TrnthAttack attack;
	Collider[] colliders;
	// public int damage;
	public void execute(){
		if(pc)colliders=pc.colliders;
		foreach(Collider e in colliders){
			var dr=e.GetComponent<TrnthAttackReceiver>();
			if(!dr)continue;
			dr.hurtWith(attack);
		}
	}
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
