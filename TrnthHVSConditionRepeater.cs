using UnityEngine;
using System.Collections;

public class TrnthHVSConditionRepeater : TrnthHVSCondition {
	public float delay=1;
	public float noise=0;
	public int length;
	// public TrnthHVSCondition onEnd;
	public override void send(){		
		base.send();
		waveNow-=1;
		if(waveNow>0){
			Invoke("send",delay+Random.value*noise);
		}
			// else if(onEnd)onEnd.send();
	}
	public void start(){
		CancelInvoke();
		if(length==0)waveNow=Mathf.Infinity;
		else waveNow=length;
		Invoke("send",delay+Random.value*noise);
	}
	float waveNow=0;
	void OnEnable(){
		start();
	}
	void OnDisable(){
		CancelInvoke();
	}
}
