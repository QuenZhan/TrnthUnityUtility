using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthMotion : TrnthMonoBehaviour {
	public TrnthMotionExecuter executor;
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
	public GameObject toLookAt;
	public Collider[] attackers;
	public CharacterController ccr;
	public void executed(){
		a.s=cooldown;
	}
	public void execute(){
		if(!isOff())return;
		if(!isOn())return;
		if(!a.a)return;
		if(groundedNeeded&&!ccr.isGrounded)return;
		executor.add(this);
		// Debug.Log("ddd");
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
}
