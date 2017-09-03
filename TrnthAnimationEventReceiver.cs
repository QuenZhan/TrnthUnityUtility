using UnityEngine;
using System.Collections;
using System;

public class TrnthAnimationEventReceiver : MonoBehaviour {
	// public bool log;
	// public override
	public bool log;
	public TrnthAnimatorProxy animatorProxy;
	void attack(){
		if(log)Debug.Log("Animation Event");
		if(animatorProxy)animatorProxy.exectureEvent();
		// execute();
	}
	void NewEvent(){
		attack();
	}
}
