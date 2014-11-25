using UnityEngine;
using System.Collections;

public class TrnthAnimatorSpeed : TrnthAnimator {
	public TrnthCreature ccc;
	public Transform target;
	public float deltaMax;
	Vector3 _pos;
	void Start(){
		if(!ccc&&!target)Destroy(gameObject);
	}
	void Update (){
		if(ccc)animator.SetFloat(parameterName,ccc.walkRate);
		if(target&&_pos!=target.position){
			var delta=target.position-_pos;
			animator.SetFloat(parameterName,delta.magnitude/deltaMax);
			_pos=target.position;
		}
	}
}
