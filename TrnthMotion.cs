using UnityEngine;
using System.Collections;
using TRNTH;
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class TrnthMotion : TrnthMonoBehaviour {
	public enum Condition{stay,enter,exit,everyframe,none,free}
	public TrnthMotionExecuter executor;
	public Condition condition=Condition.stay;
	public bool groundedNeeded;
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
	public CharacterController ccr;
	public void executed(){
		a.s=cooldown;
	}
	public void execute(){
		// if(!enabled)return;
		if(condition==Condition.none)return;
		if(!isOff())return;
		if(!isOn())return;
		if(!a.a)return;
		if(groundedNeeded&&!ccr.isGrounded)return;
		executor.add(this);
	}
	Alarm a=new Alarm();
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
	void Update(){
		if(condition!=Condition.everyframe){
			enabled=false;
			return;
		}
		execute();
	}
	void OnFree(){
		if(condition==Condition.free)execute();
	}
}
