using UnityEngine;
using System.Collections;
[RequireComponent(typeof(TrnthHVSCondition))]
public class TrnthHVSAction : TrnthHVS {
	public float delay=0;
	[ContextMenu("execute")]
	public void execute(){
		if(delay==0){
			_execute();
		}else {
			CancelInvoke();
			Invoke("_execute",delay);
		}
		// execute();
	}
	[ContextMenu("subscribe")]
	public void subscribe(){
		// if(debugLog)Debug.Log("subscribe");
		if(isSubscribed)return;
		isSubscribed=true;
		var conditions=GetComponents<TrnthHVSCondition>();
		foreach(var e in conditions){
			e.callback-=execute;
			e.callback+=execute;
			// log();
		}
	}
	public override string extraMsg{get{return "Action";}}
	protected virtual void _execute(){
		log();
	}
	bool isSubscribed;
}
