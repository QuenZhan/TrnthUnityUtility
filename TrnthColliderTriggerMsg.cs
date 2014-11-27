 // for trigger event

using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthColliderTriggerMsg : TrnthMonoBehaviour {
	public GameObject target;
	public bool log=false;
	public string methodName="onHit";
	public string[] include;
	public GameObject onHit;
	public virtual void execute(Collider col,string from){
		if(log)Debug.Log(col.name+" , "+from);
		var q=from tag in include
			where col.name.Contains(tag)
			select tag;
		if(include.Length  >0&&q.ToArray().Length>0);
		else return;
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
