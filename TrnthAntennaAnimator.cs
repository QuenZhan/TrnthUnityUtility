using UnityEngine;
using System.Collections;

public class TrnthAntennaAnimator : TrnthAntenna {
	public Animator animator;
	public float delayPlay;
	public string parameter;
	public void trigger(){
		Invoke("_trigger",delayPlay);
	}
	void _trigger(){
		animator.SetTrigger(parameter);
	}
}
