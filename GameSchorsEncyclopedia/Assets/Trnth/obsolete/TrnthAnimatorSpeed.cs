using UnityEngine;
using System.Collections;

public class TrnthAnimatorSpeed : TrnthAnimator {
	public CharacterController ccr;
	// public TrnthCreature ccc;
	// public AIPath aiPath;
	// public Transform target;
	public float deltaMax;
	Vector3 _pos;
	void OnDisable(){
		animator.SetFloat(parameterName,0);
	}
	void Update (){
		// if(ccc)animator.SetFloat(parameterName,ccc.speedNow);
		// if(aiPath)animator.SetFloat(parameterName,aiPath.speed);
		if(ccr){
			animator.SetFloat(parameterName,ccr.velocity.magnitude);
			// Debug.Log(ccr.velocity);
		}
		// if(target&&_pos!=target.position){
		// 	var delta=target.position-_pos;
		// 	var dt=Time.deltaTime;
		// 	animator.SetFloat(parameterName,delta.magnitude/dt);
		// 	_pos=target.position;
		// }
	}
}
