using UnityEngine;
using System.Collections;

public class TrnthRigidFollow : TrnthMonoBehaviour {
	public GameObject target;
	public float speed;
	Rigidbody _rigidbody;
	void Start(){
		_rigidbody=GetComponent<Rigidbody>();
	}
	void FixedUpdate(){
		var vec=target.transform.position-pos;
		vec=Vector3.ClampMagnitude(vec,speed);
		_rigidbody.velocity=vec;
	}
	void OnCollisionStay(Collision collision){
		_rigidbody.AddForce(-collision.relativeVelocity*100);
	}
}
