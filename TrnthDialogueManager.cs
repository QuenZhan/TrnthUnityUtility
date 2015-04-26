using UnityEngine;
using System.Collections;

public class TrnthDialogueManager : MonoBehaviour {
	public int index;
	public TrnthDialogueModel[] dialogues;
	[System.NonSerialized]
	public TrnthDialogueModel dialogue;
	public TrnthHVSCondition onStart;
	public TrnthHVSCondition onNext;
	public TrnthHVSCondition onEnd;
	public void next(){
		if(index>=dialogues.Length){
			trigger(onEnd);
			return;
		}
		var dia=dialogues[index];
		dialogue=dia;
		CancelInvoke();
		Invoke("next",dia.duration);
		index++;
		trigger(onNext);
	}
	public void start(){
		trigger(onStart);
		index=0;
		next();
	}
	void trigger(TrnthHVSCondition go){
		if(go)go.send();
	}
	void OnEnable(){
		start();
	}
}