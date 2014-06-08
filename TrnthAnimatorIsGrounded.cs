using UnityEngine;
using System.Collections;

public class TrnthAnimatorIsGrounded : TrnthAnimator {
	public TrnthAntenna antenna;
	public CharacterController ccr;
	void Update () {
		animator.SetBool(parameterName,ccr.isGrounded);
	}
}
