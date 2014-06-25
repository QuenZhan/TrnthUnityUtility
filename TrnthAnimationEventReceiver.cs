using UnityEngine;
using System.Collections;
using System;

public class TrnthAnimationEventReceiver : MonoBehaviour {
	public Collider[] cols;
	public bool restAfterEnd;
	public float duration=0.3f;
	public Action onBegin;
	public Action onEnd;
	public void abort(){
		foreach(var col in cols){col.enabled=false;}
		onEnd=null;
		cols=new Collider[0];
		onBegin=null;
	}
	void begin(){
		// Debug.Log("安安");
		foreach(var col in cols){col.enabled=true;			}
		if(onBegin!=null)onBegin();
		if(restAfterEnd)onBegin=null;
		Invoke("end",duration);
	}
	void end(){
		foreach(var col in cols){col.enabled=false;			}
		if(onEnd!=null)onEnd();
		if(restAfterEnd){
			cols=new Collider[0];
			onEnd=null;			
		}
	}

}
