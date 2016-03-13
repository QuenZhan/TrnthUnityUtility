using UnityEngine;
using System.Collections;

public class TrnthRadioUpdate : MonoBehaviour {
	public TrnthRadio radio;
	public float valuePerSecond=-10;
	public GameObject onEnd;
	public TrnthHVSCondition onEnd_;
	// public TrnthHVSCondition onZero;
	// public TrnthHVSCondition onFull;
	// Update is called once per frame
	void Update () {
		radio.value+=valuePerSecond*Time.deltaTime;
		if(radio.rate>1||radio.rate<0){
			if(onEnd)onEnd.SetActive(true);
			if(onEnd_)onEnd_.send();
		}
		// if(radio.rate>1){
		// 	if(onFull)onFull.send();
		// }
		// if(radio.rate<0){
		// 	if(onZero)onZero.send();
		// }
		// if(onEnd){
		// }
		radio.clamp();
	}
}
