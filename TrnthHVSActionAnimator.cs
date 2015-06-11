using UnityEngine;
using System.Collections;

public abstract class TrnthHVSActionAnimator : TrnthHVSAction {
	public Animator animator;
	public string parameterName="speed";
	public void setup(){
		if(!animator)animator=GetComponent<Animator>();
	}
	protected override void _execute(){
		setup();
	}
}
