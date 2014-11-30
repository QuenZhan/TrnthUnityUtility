 // for trigger event

using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthActivatorCollision : TrnthActivator {
	public string[] include;
	void filter(Collider col){
		var q=from tag in include
			where col.name.Contains(tag)
			select tag;
		if(!(include.Length  >0&&q.ToArray().Length>0))return;
		execute();
	}
	void OnTriggerEnter(Collider col){
		if(log)Debug.Log(name+" : "+col.name+" , trigger");
		filter(col);
	}
	void OnCollisionEnter(Collision collision){
		if(log)Debug.Log(name+" : "+collision.collider.name+" , not trigger");
		filter(collision.collider);
	}
}
