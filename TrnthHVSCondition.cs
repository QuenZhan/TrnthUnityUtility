using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TrnthHVSCondition : TrnthHVS {
	public event System.Action<TrnthHVSCondition> callback=delegate(TrnthHVSCondition condition){};
	public virtual void send(){
		if(!isFeeded)feed();
		callback(this);
		queue=new Queue<Section>(sections);
		deSection();
	}
	
	Section[] sections;
	Queue<Section> queue;
	bool isFeeded;
	// [ContextMenu("Feed")]
	void feed(){
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
	[ContextMenu("Send")]
	void _send(){
		send();
	}
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
	// [System.Serializable]
	// public 
	struct Section{
		public TrnthHVSAction[] actions;
		public float duration;
	}
}
