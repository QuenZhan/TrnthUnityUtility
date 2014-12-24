using UnityEngine;
using System.Collections;

public class TrnthCreatureFriction : MonoBehaviour {
	public TrnthCreature creature;
	public float valuePerSecound=1;
	void FixedUpdate () {
		float magnitude=creature.vecForce.magnitude-valuePerSecound*Time.deltaTime;
		if(magnitude<0)magnitude=0;
		// creature.vecForce;
		creature.vecForce=Vector3.ClampMagnitude(creature.vecForce,magnitude);
	}
}
