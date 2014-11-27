using UnityEngine;
using System.Collections;

public class TrnthRadioUpdate : MonoBehaviour {
	public TrnthRadio radio;
	public float valuePerSecond=-10;
	public GameObject onEnd;
	// Update is called once per frame
	void Update () {
		radio+=valuePerSecond*Time.deltaTime;
		if(onEnd){
			if(radio.rate>1||radio.rate<0)onEnd.SetActive(true);			
		}
	}
}
