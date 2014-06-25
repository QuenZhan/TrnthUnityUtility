using UnityEngine;
using System.Collections;
using TRNTH;
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class TrnthAntenna : TrnthMonoBehaviour{
	[HideInInspector]public bool isTriggerStay;
	public void stay(){
		isTriggerStay=true;
		enabled=true;
		a.s=0.03f;
	}
	Alarm a=new Alarm();
	void OnCollisiionEnter(){
		stay();
	}
	void OnCollisiionStay(){
		stay();
	}
	void OnCollisiionExit(){
		// isTriggerStay=false;
	}
	void OnTriggerStay(){
		// stay();
	}
	void OnTriggerExit(){
		// isTriggerStay=false;
	}
	void Update(){
		if(!a.a)return;
		enabled=false;
		isTriggerStay=false;
		SendMessage("OnFree",SendMessageOptions.DontRequireReceiver);
	}
}
