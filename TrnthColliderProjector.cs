using UnityEngine;
using System.Collections;

public class TrnthColliderProjector : TrnthMonoBehaviour {
	public GameObject target;
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(pos,transform.forward,out hit)){
			target.transform.position=hit.point;
		}

	}
}
