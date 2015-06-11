using UnityEngine;
using System.Collections;
[RequireComponent(typeof(TrnthHVSCondition))]
public abstract class TrnthHVSAction : TrnthHVS {
	[ContextMenu("execute")]
	public void execute(){
		execute(null);
	}
	public void execute(TrnthHVSCondition condition){
		if(!enabled)return;
		_execute();
	}
	protected abstract void _execute();
	protected void send(TrnthHVSCondition condition){
		if(condition)condition.send();
	}
	void Start(){
		// for show enabled / disabled checkbox on inspector
	}
}
