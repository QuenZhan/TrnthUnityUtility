using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class TrnthAntenna : MonoBehaviour{
	public bool isTriggerStay;
	void OnTriggerStay(){
		isTriggerStay=true;
	}
	void OnTriggerExit(){
		isTriggerStay=false;
	}
}
