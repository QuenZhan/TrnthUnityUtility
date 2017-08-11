using UnityEngine;
using System.Collections;

public class TrnthAnimatorRandom : TrnthAnimator {
	// public bool yes;
	public int steps;
	public override void execute(){
		if(steps==0){
			animator.SetFloat(parameterName,Random.value);
		}else{
			var value=Mathf.Floor(Random.value*steps)/steps;
			animator.SetFloat(parameterName,value);
		}
	}
}
