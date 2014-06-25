using UnityEngine;
using System.Collections.Generic;
[RequireComponent (typeof (TrnthInput))]
public class TrnthInputToggler:TrnthMonoBehaviour{
	public GameObject[] gobjs;
	public TrnthInput input;
	public bool reverse;
	public void toggle(bool yes){
		foreach(GameObject e in gobjs){
			e.SetActive(reverse?!yes:yes);
		}
	}
	public int add(GameObject obj){
		var list=new List<GameObject>();
		list.Add(obj);
		this.gobjs=list.ToArray();
		return this.gobjs.Length;
	}
	void Update(){
		toggle(input.isHold);
	}
	void OnInputDown(){
		toggle(true);	
	}
	void OnInputUp(){
		toggle(false);	
	}
}