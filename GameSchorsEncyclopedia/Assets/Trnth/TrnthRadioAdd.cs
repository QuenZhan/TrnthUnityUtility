using UnityEngine;
using System.Collections;

public class TrnthRadioAdd : MonoBehaviour {
	public TrnthRadio radio;
	public float value;
	void OnEnable(){
		radio.value+=value;
	}
}
