using UnityEngine;
using System.Collections;
using System;

public class TrnthAnimationEventReceiver : TrnthActivator {
	// public bool log;
	// public override
	void attack(){
		if(log)Debug.Log("Animation Event");
		execute();
	}
	void NewEvent(){
		attack();
	}
}
