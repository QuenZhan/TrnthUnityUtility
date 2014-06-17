using UnityEngine;
using System.Collections;

public class TrnthRigidPusher : TrnthMonoBehaviour {
	public string collideTag;
	public float force=10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnControllerColliderHit(ControllerColliderHit hit){
		return;
		var rigid=hit.rigidbody;
		if(rigid){
			var vec=rigid.transform.position-pos;
			rigid.AddForce(vec.normalized*force);

		}

	}
	void OnTriggerStay(Collider col){
		if(col.gameObject.tag==collideTag){
			var rigid=col.transform.parent.rigidbody;
			var vec=rigid.transform.position-pos;
			rigid.AddForce(vec.normalized*force);

		}
	}
}
