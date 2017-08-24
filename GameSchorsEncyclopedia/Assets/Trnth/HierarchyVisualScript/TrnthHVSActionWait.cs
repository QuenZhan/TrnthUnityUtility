using UnityEngine;
using System.Collections;

public class TrnthHVSActionWait : TrnthHVSAction {
	public float Delay=1;
	public float noise=0;
	public bool cancelOnDisable=true;
	public TrnthHVSCondition onTimesUp;
	protected override void _execute(){
		if(enabled||!cancelOnDisable)Invoke("timesup",Delay+Random.value*noise);
	}
	void timesup(){
		onTimesUp.send();
	}
	void OnDisable(){
		if(cancelOnDisable)CancelInvoke();
	}
}
