using UnityEngine;
using System.Collections;

public class TrnthHVSActionAnimator : TrnthHVSAction {
	public Animator animator;
	public TrnthAnimatorProxy proxy;
	public string parameterName="speed";
	public void setup(){
		if(proxy)animator=proxy.animator;
		if(!animator)animator=GetComponent<Animator>();
	}
	protected override void _execute(){
		base._execute();
		setup();
	}
}
