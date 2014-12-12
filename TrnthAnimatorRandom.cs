using UnityEngine;
using System.Collections;

public class TrnthAnimatorRandom : TrnthAnimator {
	// public bool yes;
	public override void execute(){
		animator.SetFloat(parameterName,Random.value);
	}
}
