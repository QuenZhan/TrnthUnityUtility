using UnityEngine;
using System.Collections;

public class TrnthMotion : MonoBehaviour {
	public TrnthMotionExecuter executor;
	public int priority;
	public float delayAnimator;
	public float delayForce;
	public float cooldown;
	public string animatorParameter;
	public Vector3 forceWorld;
	public Vector3 forceLocal;
	public TrnthAntenna[] antennasNeeded;
	public TrnthAntenna[] antennasFree;
	bool isOn(){
		foreach(TrnthAntenna e in antennasNeeded){
			if(!e.isTriggerStay)return false;
		}
		return true;
	}
	bool isOff(){
		foreach(TrnthAntenna e in antennasFree){
			if(e.isTriggerStay)return false;
		}
		return true;
	}
	void OnTriggerStay(){
		if(!isOff())return;
		if(!isOn())return;
		executor.add(this);
	}
}
