using UnityEngine;
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