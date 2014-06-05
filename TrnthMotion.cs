using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class TrnthMotion : MonoBehaviour {
	public enum Condition{stay,enter,exit}
	public TrnthMotionExecuter executor;
	public Condition condition=Condition.stay;
	public int priority;
	public float delayAnimator;
	public float delayForce;
	public float cooldown;
	public string animatorParameter;
	public Vector3 forceWorld;
	public Vector3 forceLocal;
	public TrnthAntenna[] antennasNeeded;
	public TrnthAntenna[] antennasFree;
	public GameObject toDeactivate;
	public void execute(){
		if(!enabled)return;
		if(!isOff())return;
		if(!isOn())return;
		executor.add(this);
	}
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
	void Start(){}
	void OnCollistionStay(){
		execute();
	}
	void OnTriggerStay(){
		if(condition==Condition.stay)execute();
	}
	void OnTriggerExit(){
		if(condition==Condition.exit)execute();
	}
}
