using UnityEngine;
using System.Collections;
using System;

public class TrnthAnimationEventReceiver : TrnthActivator {
	public bool log;
	void attack(){
		if(log)Debug.Log("Animation Event");
		execute();
	}
}
