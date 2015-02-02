using UnityEngine;
using System.Collections;
using System.Linq;
public class TrnthHVSConditionColliderEnter : TrnthHVSCondition {
	public bool includeTrigger=true;
	public string[] include;
	public Collider col{get{return _col;}}
	public override string extraMsg{get{
		return "Collider : "+_col.name;
	}}
	void sendFilter(){
		if(include.Length==0)send();
		var q=from e in include
			where _col.name.Contains(e)
			select e;

		log();
		if(q.ToArray().Length>0)send();
	}
	void OnTriggerEnter(Collider collider){
		if(!includeTrigger)return;
		_col=collider;
		sendFilter();
	}
	void OnCollisionEnter(Collision collision){
		_col=collision.collider;
		sendFilter();
	}
	Collider _col;
}
