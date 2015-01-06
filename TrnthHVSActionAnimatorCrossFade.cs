using UnityEngine;
using System.Collections;

public class TrnthHVSActionAnimatorCrossFade : TrnthHVSActionAnimator {
	public string stateName;
	public float transitionDuration=0.7f;
	protected override void _execute(){
		base._execute();
		if(variable)animator=variable.read<Animator>();
		animator.CrossFade(stateName,transitionDuration);
	}
}
