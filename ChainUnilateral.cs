using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
public class ChainUnilateral : TRNTH.MonoBehaviour {
	public Transform target;
	public float gravityScale;
	public float disRestriction=1;
	public float drag=0.9f;
	public float fAntiGravity=0.5f;
	//public Rigidbody;
	public void excute(){
		foreach(var e in transform){

		}
	}
	Joint joint;
	// Use this for initialization
	
	void Start () {
		//joint.
		if(!target)target=tra.parent;
		tra.parent=null;
	}
	void FixedUpdate (){
		var vec=pos-target.position;
		rigidbody.AddForce(-Physics.gravity*fAntiGravity);
		if(vec.magnitude>disRestriction){
			pos=target.position+vec.normalized*disRestriction;
			//rigidbody.velocity+=-vec.normalized*rigidbody.velocity.magnitude*1.1f;
			//rigidbody.velocity*=drag;
			var ff=-vec.normalized*rigidbody.velocity.magnitude*1.01f;
			rigidbody.AddForce(ff);
			//rigidbody.velocity*=0;
			target.rigidbody.AddForce(-Physics.gravity*1.0f);
			//if(target.rigidbody)target.rigidbody.AddForce(-ff*0.9f);
			if(target.rigidbody){
			//rigidbody.AddForce(-vec);
				target.rigidbody.AddForce(vec);
				rigidbody.AddForce(ff);
			}
			return;
			var vecFace=Vector3.Cross(-vec,rigidbody.velocity);
			var vec3=Vector3.Cross(vecFace,-vec)*drag;
			if(vec3.x==Mathf.Infinity
				||vec3.x==Mathf.NegativeInfinity
				||vec3.y==Mathf.NegativeInfinity
				||vec3.z==Mathf.NegativeInfinity
				||vec3.y==Mathf.Infinity
				||vec3.z==Mathf.Infinity)rigidbody.velocity=Vector3.zero;
			else rigidbody.velocity=vec3;
		}
	}
}
