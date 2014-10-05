using UnityEngine;
using System.Collections;

public class TrnthRigidForcer : MonoBehaviour {
	public Rigidbody rigid;
	public Vector3 forceInit;
	void Awake(){
		if(!rigid)rigid=rigidbody;
	}
	public void execute(){
		rigid.velocity=forceInit;
	}
	void OnSpawned(){
		execute();
	}
	void Start(){
		execute();
	}
}
