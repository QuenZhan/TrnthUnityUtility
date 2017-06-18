using UnityEngine;
using System.Collections;

public class TrnthHVSActionAnimatorBool : TrnthHVSActionAnimator {
	public bool yes=true;
	protected override void _execute(){
		base._execute();
		if(variable)animator=variable.read<Animator>();
		animator.SetBool(parameterName,yes);
	}
}
