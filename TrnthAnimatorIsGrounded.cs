using UnityEngine;
using System.Collections;

public class TrnthAnimatorIsGrounded : TrnthAnimator {
	public TrnthAntenna antenna;
	void Update () {
		animator.SetBool(parameterName,antenna.isTriggerStay);
	}
}
