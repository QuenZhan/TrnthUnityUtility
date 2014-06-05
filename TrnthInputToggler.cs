using UnityEngine;
[RequireComponent (typeof (TrnthInput))]
public class TrnthInputToggler:TRNTH.MonoBehaviour{
	public GameObject[] gobjs;
	public TrnthInput input;
	public void toggle(bool yes){
		foreach(GameObject e in gobjs){
			e.SetActive(yes);
		}
	}
	void Update(){		
		toggle(input.isHold);
	}
}