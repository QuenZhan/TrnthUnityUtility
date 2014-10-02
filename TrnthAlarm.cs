using UnityEngine;
using System.Collections.Generic;

// [System.Serializable]
public class TrnthAlarm{
	static public TrnthAlarm[] alarms{
		get{
			TrnthAlarm[] a=new TrnthAlarm[10];
			for(int i=0;i<a.Length;i++){
				a[i]=new TrnthAlarm();
			}
			return a;
		}			
	}
	public TrnthAlarm(){}
	public TrnthAlarm(float time){
		this.s=time;
	}
	public bool isRealTime=false;
	public bool a{
		get {
			if(isRealTime){
				return Time.realtimeSinceStartup>end;
			}
			return Time.time>end;;
		}
	}
	public float s{
		set{
			start=Time.time;
			if(isRealTime)start=Time.realtimeSinceStartup;
			end=start+value;
		 }
	}
	public void iss(float num){
		s=num;
	}
	public bool iss(){
		return a;
	}
	public float rate{
		get{
			return (Time.time-start)/(end-start+Mathf.Epsilon);
		}
	}
	public float countDown{
		get{
			return Mathf.Clamp(end-Time.time,0,Mathf.Infinity);
		}
	}
	public void routine(float time,System.Action boo){
		if(!a)return;
		s=(time);
		boo();
	}
	float start=0.0f;
	float end=1.0f;
}
