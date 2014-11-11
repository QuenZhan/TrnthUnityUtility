using UnityEngine;
using System.Collections;

public class TrnthCreatureForcer : MonoBehaviour {
	public TrnthCreature creature;
	public Vector3 force;
	public void exectue(){
		creature.vecForce=force;
	}
	void OnEnable(){
		exectue();
	}
}
