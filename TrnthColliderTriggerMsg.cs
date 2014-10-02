 // for trigger event

using UnityEngine;
using System.Collections;

public class TrnthColliderTriggerMsg : TrnthMonoBehaviour {
	public GameObject target;
	public string methodName="onHit";
	void OnTriggerEnter(Collider col){
		// Debug.Log(target.name);
		// Debug.Log(col.name);
		if(methodName!=""
			&&target
			&&target.activeInHierarchy
			)target.SendMessage(methodName,new GameObject[]{gameObject,col.gameObject});
	}
}
