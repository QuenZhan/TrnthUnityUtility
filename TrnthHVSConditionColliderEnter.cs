using UnityEngine;
using System.Collections;
public class TrnthHVSConditionColliderEnter : TrnthHVSCondition {
	public bool includeTrigger=true;
	public override string extraMsg{get{
		return "Collider : "+_col.name;
	}}
	void OnTriggerEnter(Collider collider){
		_col=collider;
		if(includeTrigger)send();
	}
	void OnCollisionEnter(Collision collision){
		_col=collision.collider;
		send();	
	}
	Collider _col;
}
