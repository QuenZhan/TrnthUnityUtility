using UnityEngine;
using System.Collections;
public class TrnthHVSCondition : TrnthHVS {
	public override string extraMsg{get{return"Condition";}}
	[ContextMenu("execute")]
	public void executeContextMenu(){
		execute();
	}
	public virtual void execute(){
		log();
		if(callback!=null)callback();
	}
	// public delegate void Callback();
	public event System.Action callback;
}
