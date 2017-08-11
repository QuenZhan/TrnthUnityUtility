using UnityEngine;
using System.Collections;

public class TrnthHVSActionAnimatorFloat : TrnthHVSActionAnimator {
	public float value;
	protected override void _execute(){
		base._execute();
		animator.SetFloat(parameterName,value);
	}
}
