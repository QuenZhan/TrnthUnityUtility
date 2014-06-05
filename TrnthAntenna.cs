using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class TrnthAntenna : MonoBehaviour{
	public bool isTriggerStay;
	//Alarm a=new Alarm();
	void OnCollisiionStay(){
		isTriggerStay=true;
		enabled=true;
	}
	void OnCollisiionExit(){
		// isTriggerStay=false;
	}
	void OnTriggerStay(){
		isTriggerStay=true;
		enabled=true;
	}
	void OnTriggerExit(){
		// isTriggerStay=false;
	}
	void Update(){
		enabled=false;
		isTriggerStay=false;
	}
}
