using UnityEngine;
using System.Collections;

public class TrnthCreatureForcer : MonoBehaviour {
	public TrnthCreature creature;
	public Transform traLocal;
	public Vector3 force;
	public void exectue(){
		if(traLocal){
			var vec=traLocal.TransformDirection(force);
			// Debug.Log(vec);
			creature.vecForce=vec;
		}else{
			creature.vecForce=force;
		}
	}
	void OnEnable(){
		exectue();
	}
}
