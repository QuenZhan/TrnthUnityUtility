using UnityEngine;
using System.Collections;
[RequireComponent(typeof(TrnthHVSCondition))]
public class TrnthHVSAction : TrnthHVS {
	public override string extraMsg{get{return "TrnthHVSAction";}}
	public virtual void execute(){
		log();
	}
	void Awake(){
		var conditions=GetComponents<TrnthHVSCondition>();
		foreach(var e in conditions){
			e.callback+=execute;
			// log();
		}
	}
}
