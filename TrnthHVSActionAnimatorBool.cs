using UnityEngine;
using System.Collections;

public class TrnthHVSActionAnimatorBool : TrnthHVSActionAnimator {
	public bool yes=true;
	protected override void _execute(){
		base._execute();
		animator.SetBool(parameterName,yes);
	}
}
