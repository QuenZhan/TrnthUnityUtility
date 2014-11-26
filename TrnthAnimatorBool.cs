using UnityEngine;
using System.Collections;

public class TrnthAnimatorBool : TrnthAnimator {
	public bool yes=true;
	void OnEnable(){
		animator.SetBool(parameterName,yes);
	}
}
