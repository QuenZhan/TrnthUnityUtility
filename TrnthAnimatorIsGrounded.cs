using UnityEngine;
using System.Collections;

public class TrnthAnimatorIsGrounded : TrnthAnimator {
	public CharacterController ccr;
	void Update () {
		animator.SetBool(parameterName,ccr.isGrounded);
	}
}
