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
	void OnTriggerStay(Collider col){
		if(col.gameObject.tag==collideTag){
			var rigid=col.transform.parent.GetComponent<Rigidbody>();
			var vec=rigid.transform.position-Position;
			rigid.AddForce(vec.normalized*force);

		}
	}
}
