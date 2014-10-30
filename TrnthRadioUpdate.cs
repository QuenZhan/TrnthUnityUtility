using UnityEngine;
using System.Collections;

public class TrnthRadioUpdate : MonoBehaviour {
	public TrnthRadio radio;
	public float value=-10;
	// Update is called once per frame
	void Update () {
		radio+=value*Time.deltaTime;
	}
}
