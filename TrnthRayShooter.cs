using UnityEngine;
using System.Collections;

public class TrnthRayShooter : TRNTH.MonoBehaviour {
	public GameObject target;
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(pos,transform.forward,out hit)){
			target.transform.position=hit.point;
		}

	}
}
