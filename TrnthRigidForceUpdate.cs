using UnityEngine;
using System.Collections;

public class TrnthRigidForceUpdate : MonoBehaviour {
	public Rigidbody Rigidbody;
	public Vector3 Force;
	public void FixedUpdate(){
		Rigidbody.velocity+=Force*Time.deltaTime;
	}
}
