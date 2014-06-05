using UnityEngine;
using System.Collections;

public class TrnthAnimatorAntennaBool : TrnthAnimator {
	public TrnthAntenna antenna;
	public bool reverse=false;
	void Update () {
		bool yes=antenna.isTriggerStay;
		yes=reverse?!yes:yes;
		animator.SetBool(parameterName,yes);
	}
}
