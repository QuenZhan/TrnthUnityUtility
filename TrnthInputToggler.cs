using UnityEngine;
[RequireComponent (typeof (TrnthInput))]
public class TrnthInputToggler:TRNTH.MonoBehaviour{
	public GameObject[] gobjs;
	public void toggle(bool yes){
		foreach(GameObject e in gobjs){
			e.SetActive(yes);
		}
	}
	void OnInputDown(){
		toggle(true);
	}
	void OnInputUp(){
		toggle(false);
		
	}
}