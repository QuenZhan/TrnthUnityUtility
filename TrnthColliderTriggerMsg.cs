using UnityEngine;
using System.Collections;

public class TrnthColliderTriggerMsg : TrnthMonoBehaviour {
	public GameObject target;
	public string methodName;
	void OnTriggerEnter(Collider col){
		// Debug.Log("bbb");
		if(methodName!="")target.SendMessage(methodName,new GameObject[]{gameObject,col.gameObject});
	}
}
