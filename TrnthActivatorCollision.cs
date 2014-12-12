 // for trigger event

using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthActivatorCollision : TrnthActivator {
	public string[] include;
	public bool onEnter=true;
	public bool onExit;
	public bool onTrigger;
	void filter(Collider col){
		if(include.Length <1){
			execute();
			return ;
		}
		var q=from tag in include
			where col.name.Contains(tag)
			select tag;
		if(q.ToArray().Length <1)return;
		execute();
	}
	void OnTriggerEnter(Collider col){
		if(!onEnter||!onTrigger)return;
		if(log)Debug.Log(name+" : "+col.name+" , trigger");
		filter(col);
	}
	void OnCollisionEnter(Collision collision){
		if(!onEnter)return;
		if(log)Debug.Log(name+" : "+collision.collider.name+" , not trigger");
		filter(collision.collider);
	}
	void OnTriggerExit(Collider col){
		if(!onExit||!onTrigger)return;
		if(log)Debug.Log(name+" : "+col.name+" , trigger");
		filter(col);
	}
	void OnCollisionExit(Collision collision){
		if(!onExit)return;
		if(log)Debug.Log(name+" : "+collision.collider.name+" , not trigger");
		filter(collision.collider);
	}

}
