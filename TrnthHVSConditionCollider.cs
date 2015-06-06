using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthHVSConditionCollider : TrnthHVSCondition {
	public bool includeTrigger=true;
	public string[] include;
	public Collider col{get{return _col;}}
	public override string extraMsg{get{
		return "Collider : "+_col.name;
	}}
	public event System.Action<TrnthHVSConditionCollider,Collider> onCollided=delegate{};
	protected void sendFilter(Collider col){
		onCollided(this,col);

		if(include.Length==0){
			_col=col;
			send();
		}

		var q=from e in include
			where col.name.Contains(e)
			select e;

		// log();
		if(q.ToArray().Length>0){
			_col=col;
			send();
		}
	}
	Collider _col;
}
