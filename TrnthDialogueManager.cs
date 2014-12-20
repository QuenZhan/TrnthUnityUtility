using UnityEngine;
using System.Collections;

public class TrnthDialogueManager : MonoBehaviour {
	public int index;
	public TrnthDialogueModel[] dialogues;
	public TrnthDialogueModel dialogue;
	public GameObject onStart;
	public GameObject onNext;
	public GameObject onEnd;
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
	void trigger(GameObject go){
		if(!go)return;
		go.SetActive(true);
		go.SetActive(false);
	}
	void OnEnable(){
		start();
	}
}