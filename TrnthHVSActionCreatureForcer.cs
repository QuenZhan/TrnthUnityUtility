using UnityEngine;
using System.Collections;

public class TrnthHVSActionCreatureForcer : TrnthHVSAction {
	public TrnthCreature creature;
	public Transform traLocal;
	public Vector3 force;
	protected override void _execute(){
		if(traLocal){
			var vec=traLocal.TransformDirection(force);
			// Debug.Log(vec);
			creature.vecForce=vec;
		}else{
			creature.vecForce=force;
		}
	}
}
