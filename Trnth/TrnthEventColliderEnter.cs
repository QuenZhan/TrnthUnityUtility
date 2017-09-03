using UnityEngine;
using System.Collections;

public class TrnthEventColliderEnter : MonoBehaviour {
	public event System.Action<TrnthEventColliderEnter,Collider> onEnter=delegate {};
	void OnTriggerEnter(Collider collider){
		onEnter(this,collider);
	}
	void OnCollisionEnter(Collision collision){
		onEnter(this,collision.collider);
	}
}
