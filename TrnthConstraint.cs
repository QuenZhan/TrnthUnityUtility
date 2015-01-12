using UnityEngine;
using System.Collections;

public class TrnthConstraint : MonoBehaviour {
	public Transform target;
	void Awake(){
		if(!target)target=transform;
	}
}
