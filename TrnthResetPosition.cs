using UnityEngine;
using System.Collections;

public class TrnthResetPosition : MonoBehaviour {
	public Transform target;
	void Awake(){
		if(!target)target=transform;
	}
	void OnDisable(){
		target.localPosition=Vector3.zero;
	}
}
