using UnityEngine;
using System.Collections;
[RequireComponent(typeof(TrnthHVSCondition))]
public class TrnthHVSAction : TrnthHVS {
	protected TrnthVariable variable;
	[HideInInspector]
	[SerializeField]
	public float delay=0;
	[HideInInspector]
	[SerializeField]
	protected float _delayNoise=0;
	// [ContextMenu("set noise as delay")]
	public void setNoise(){
		_delayNoise=delay;
	}
	[ContextMenu("execute immediatly")]
	public void execute(){
		execute(null);
	}
	public void execute(TrnthHVSCondition condition){
		if(!this||!enabled)return;
		if(delay==0){
			_execute();
		}else {
			CancelInvoke();
			Invoke("_execute",delay);
		}
	}
	public override string extraMsg{get{return "Action";}}
	protected virtual void _execute(){
		if(!variable)variable=GetComponent<TrnthVariable>();
		log();
	}
	protected void send(TrnthHVSCondition condition){
		if(condition)condition.send();
	}
	[ContextMenu("reset delay")]
	public void resetDelay(){
		delay=0;
	}
	protected void Start(){
		// for show enabled / disabled checkbox on inspector
	}
}
