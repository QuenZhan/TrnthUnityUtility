using UnityEngine;
using System.Collections;

public class TrnthConstraint : MonoBehaviour {
	public Transform target;
	public virtual void setup(){
		if(!target)target=transform;
	}
	public virtual void update(){

	}
	void Awake(){
		setup();
	}
	void Update(){
		update();
	}
}
