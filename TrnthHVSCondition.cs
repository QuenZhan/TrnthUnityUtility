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
		// else {
		// 	SendMessage("execute",SendMessageOptions.DontRequireReceiver);
		// }
	}
	[ContextMenu("Feed")]
	public void feed(){
		isFeeded=true;
		var actions=GetComponents<TrnthHVSAction>();
		// Debug.Log(actions.Length);
		foreach(var e in actions){
			callback-=e.execute;
			callback+=e.execute;
		}
	}
	// public delegate void Callback();
	public event System.Action callback;
	bool isFeeded;
	// void Awake(){
	// 	feed();
	// }
}
