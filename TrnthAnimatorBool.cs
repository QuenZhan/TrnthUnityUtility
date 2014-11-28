using UnityEngine;
using System.Collections;

public class TrnthAnimatorBool : TrnthAnimator {
	public bool yes=true;
	public void execute(){
		animator.SetBool(parameterName,yes);
		
	}
	void OnEnable(){
		execute();
	}
}
