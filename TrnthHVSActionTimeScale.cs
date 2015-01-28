using UnityEngine;
using System.Collections;

public class TrnthHVSActionTimeScale : TrnthHVSAction {
	public float value=1;
	protected override void _execute(){
		base._execute();
		Time.timeScale=value;
	}
}
