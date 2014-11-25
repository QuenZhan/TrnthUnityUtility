using UnityEngine;
using System.Collections;

public class TrnthAttackSender : MonoBehaviour {
	public TrnthPhysicsCast pc;
	public TrnthAttack attack;
	// public int damage;
	public void execute(){
		foreach(Collider e in pc.colliders){
			var dr=e.GetComponent<TrnthAttackReceiver>();
			if(!dr)continue;
			dr.hurtWith(attack);
		}
	}
}
