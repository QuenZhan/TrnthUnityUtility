using UnityEngine;
using System.Collections;

public class TrnthHVSConditionRepeater : TrnthHVSCondition {
	public float delay=1;
	public float noise=0;
	public int length;
	public override void execute(){		
		base.execute();
		waveNow-=1;
		if(waveNow>0){
			Invoke("execute",delay+Random.value*noise);
		}
	}
	public void start(){
		CancelInvoke();
		if(length==0)waveNow=Mathf.Infinity;
		else waveNow=length;
		Invoke("execute",delay+Random.value*noise);
	}
	float waveNow=0;
	void OnEnable(){
		start();
	}
	void OnDisable(){
		CancelInvoke();
	}
}
