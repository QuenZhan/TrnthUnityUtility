using UnityEngine;
using System.Collections;

public class TrnthAnimatorAdd : TrnthAnimator {
	public float value;
	public override void execute(){
		var value=animator.GetFloat(parameterName)+this.value;
		if(value>1)value=1;
		animator.SetFloat(parameterName,value);
	}
}
