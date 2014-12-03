using UnityEngine;
using System.Collections;
using TRNTH;
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class TrnthMotionTrigger : TrnthMotion {
	public enum Condition{stay,enter,exit,everyframe,none,free}
	public Condition condition=Condition.stay;
	public bool lookAtIt;
	void OnTriggerStay(Collider col){
		if(condition==Condition.stay)execute();
		if(lookAtIt)toLookAt=col.gameObject;
	}
	void OnTriggerExit(){
		if(condition==Condition.exit)execute();
		// toLookAt=col.gameObject;
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
