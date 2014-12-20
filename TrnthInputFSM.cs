using UnityEngine;
using System.Collections;

public class TrnthInputFSM : MonoBehaviour {
	public TrnthFSMManagerApply statusApply;
	public string button;
	void Update () {
		if(Input.GetButtonDown(button)){
			statusApply.execute();
		}
	}
}
