using UnityEngine;
using System.Collections.Generic;
[RequireComponent (typeof (TrnthInput))]
public class TrnthInputToggler:TrnthMonoBehaviour{
	public GameObject[] onHolding;
	public TrnthInput input;
	bool reverse;
	public void toggle(bool yes){
		foreach(GameObject e in onHolding){
			e.SetActive(reverse?!yes:yes);
		}
	}
	public int add(GameObject obj){
		var list=new List<GameObject>();
		list.Add(obj);
		this.onHolding=list.ToArray();
		return this.onHolding.Length;
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