using UnityEngine;
using System.Collections;

public class TrnthAnimatorRandom : TrnthAnimator {
	// public bool yes;
	void OnEnable(){
		animator.SetFloat(parameterName,Random.value);
	}
}
