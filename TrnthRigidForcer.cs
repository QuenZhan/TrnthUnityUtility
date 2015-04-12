using UnityEngine;
using System.Collections;

public class TrnthRigidForcer : MonoBehaviour {
	public Rigidbody rigid;
	public Vector3 forceInit;
	public Vector3 noise;
	void Awake(){
		if(!rigid)rigid=GetComponent<Rigidbody>();
	}
	public void execute(){
		rigid.velocity=forceInit+(new Vector3(Random.value*noise.x,Random.value*noise.y,Random.value*noise.z));
	}
	void OnEnable(){
		execute();
	}
}
