 // for trigger event

using UnityEngine;
using System.Collections;

public class TrnthColliderTriggerMsg : TrnthMonoBehaviour {
	public GameObject target;
	public bool log=false;
	public string methodName="onHit";
	void OnTriggerEnter(Collider col){
		// Debug.Log(target.name);
		if(log)Debug.Log(col.name);
		if(methodName!=""
			&&target
			&&target.activeInHierarchy
			)target.SendMessage(methodName,new GameObject[]{gameObject,col.gameObject});
	}
}
