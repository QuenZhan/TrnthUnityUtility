using UnityEngine;
using System.Collections;

public class TrnthEventCollider : MonoBehaviour {
	public event System.Action<TrnthEventCollider,Collider> onEnter=delegate {
	
		};
	public event System.Action<TrnthEventCollider,Collider> onStay=delegate {
		
	};
	public event System.Action<TrnthEventCollider,Collider> onExit=delegate {
		
	};
	void OnTriggerEnter(Collider collider){
		onEnter(this,collider);
	}
	void OnCollisionEnter(Collision collision){
		onEnter(this,collision.collider);
	}
	void OnTriggerExit(Collider collider){
		onExit(this,collider);
	}
	void OnCollisionExit(Collision collision){
		onExit(this,collision.collider);
	}
	void OnTriggerStay(Collider collider){
		onStay(this,collider);
	}
	void OnCollisionStay(Collision collision){
		onStay(this,collision.collider);
	}
}
