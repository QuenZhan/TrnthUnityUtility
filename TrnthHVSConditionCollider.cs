using UnityEngine;
using System.Collections;

public abstract class TrnthHVSConditionCollider : TrnthHVSCondition {
	public bool includeTrigger=true;
	public string[] mustInclude;
	public Collider col{get{return _col;}}
	public event System.Action<TrnthHVSConditionCollider,Collider> onCollided=delegate{};
	protected void sendFilter(Collider col){
		onCollided(this,col);

		if(mustInclude.Length==0){
			sendIt(col);
			return;
		}
		foreach(var e in mustInclude){
			if(!col.name.Contains(e))continue;
			sendIt(col);
			return;
		}
	}
	void sendIt(Collider col){
		_col=col;
		send();
	}
	Collider _col;
}
