using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TrnthHVSCondition : TrnthHVS {
	public override string extraMsg{get{return"Condition";}}
	[ContextMenu("Send")]
	public void executeContextMenu(){
		send();
	}
	public virtual void send(){
		if(!isFeeded)feed();
		log();
		callback(this);
		queue=new Queue<Section>(sections);
		deSection();
	}
	[ContextMenu("Feed")]
	public void feed(){
		isFeeded=true; 
		var hvses=GetComponents<TrnthHVS>();
		var listSection=new List<Section>();
		var listActions=new List<TrnthHVSAction>();
		var section=new Section();
		section.duration=0;
		foreach(var e in hvses){
			// Debug.Log(e);
			if(e is TrnthHVSYield){
				//end old 
				section.actions=listActions.ToArray();
				section.duration=(e as TrnthHVSYield).duration;
				listSection.Add(section);
				listActions.Clear();
				//start new 
				section=new Section();
			}
			if(e is TrnthHVSAction){
				// var action=(TrnthHVSAction)e;
				listActions.Add((TrnthHVSAction)e);
			}
		}
		section.actions=listActions.ToArray();
		listSection.Add(section);
		sections=listSection.ToArray();
	}
	public void _feed(){
		isFeeded=true; 
		var actions=GetComponents<TrnthHVSAction>();
		foreach(var e in actions){
			callback-=e.execute;
			callback+=e.execute;
		}
	}
	public event System.Action<TrnthHVSCondition> callback=delegate(TrnthHVSCondition condition){};
	Section[] sections;
	Queue<Section> queue;
	bool isFeeded;
	void Awake(){
		feed();
	}
	void deSection(){
		if(queue.Count<1)return;
		var section=queue.Dequeue();
		foreach(var e in section.actions){
			e.execute();
		}
		Invoke("deSection",section.duration);
	}
	[System.Serializable]
	public struct Section{
		public TrnthHVSAction[] actions;
		public float duration;
	}
}
