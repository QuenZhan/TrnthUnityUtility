using UnityEngine;
using System.Collections;

public class TrnthTimeScale : TrnthTriggerBase {
	public float value;
	public void execute(){
		Time.timeScale=value;
	}
}
