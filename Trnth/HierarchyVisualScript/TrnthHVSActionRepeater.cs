using UnityEngine;
using System.Collections;

public class TrnthHVSActionRepeater : TrnthHVSAction {
	public float delayBetween=1;
	public float noiseDelayBetween=0;
	public int length;
	public TrnthHVSCondition onWave;
	public TrnthHVSCondition onEnd;
	protected override void _execute(){		
		start();
	}
	public void start(){
		CancelInvoke();
		if(length==0)waveNow=Mathf.Infinity;
		else waveNow=length;
		invoke();
	}
	void wave(){
		onWave.send();
		waveNow-=1;
		if(waveNow>0){
			invoke();
		}else if(onEnd)onEnd.send();
	}
	void invoke(){
		Invoke("wave",delayBetween+Random.value*noiseDelayBetween);	
	}
	float waveNow=0;
	void OnDisable(){
		CancelInvoke();
	}
}
