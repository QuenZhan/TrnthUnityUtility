using UnityEngine;
using System.Collections;
public class TrnthHVSCondition : TrnthHVS {
	public override string extraMsg{get{return"Condition";}}
	[ContextMenu("Send")]
	public void executeContextMenu(){
		send();
	}
	public virtual void send(){
		if(!isFeeded)feed();
		log();
		if(callback!=null)callback();
	}
	[ContextMenu("Feed")]
	private void feed(){
		isFeeded=true;
		var actions=GetComponents<TrnthHVSAction>();
		foreach(var e in actions){
			callback-=e.execute;
			callback+=e.execute;
		}
	}
	public event System.Action<TrnthHVSCondition> callback=delegate(TrnthHVSCondition condition){};
	bool isFeeded;
	void Awake(){
		feed();
	}
}
