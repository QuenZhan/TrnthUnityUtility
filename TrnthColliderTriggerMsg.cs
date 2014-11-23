 // for trigger event

using UnityEngine;
using System.Collections;

public class TrnthColliderTriggerMsg : TrnthMonoBehaviour {
	public GameObject target;
	public bool log=false;
	public string methodName="onHit";
	public GameObject onHit;
	public void execute(Collider col,string from){
		if(log)Debug.Log(col.name+" , "+from);
		if(methodName!=""
			&&target
			&&target.activeInHierarchy
			)target.SendMessage(methodName,new GameObject[]{gameObject,col.gameObject});
		if(onHit)onHit.SetActive(true);
	}
	void OnTriggerEnter(Collider col){
		execute(col,"trigger");
	}
	void OnCollisionEnter(Collision collision){
		execute(collision.collider,"collision");
	}
}
