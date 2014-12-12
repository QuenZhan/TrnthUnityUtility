using UnityEngine;
using System.Collections;

public class TrnthAnimatorBool : TrnthAnimator {
	public bool yes=true;
	public override void execute(){
		animator.SetBool(parameterName,yes);		
	}
}
