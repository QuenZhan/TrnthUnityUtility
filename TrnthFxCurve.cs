using UnityEngine;
using TRNTH;
public class TrnthFxCurve:MonoBehaviour{
	public string findIt;
	public AnimationCurve curve;
	public float noise;
	public virtual void start(){
		enabled=true;		
		_timeStart=Time.time;
		var keys=curve.keys;
		var lastkey=keys[keys.Length-1];
		Invoke("end",lastkey.time);
	}
	protected virtual void update(){
	}
	protected virtual float curveValue{get{return curve.Evaluate(Time.time-_timeStart)+Random.value*noise;}}
	float _timeStart;
	void end(){
		enabled=false;
	}
	void OnEnable(){
		start();
	}
	void OnDisable(){
		CancelInvoke();
	}
	void Update(){
		update();
	}
}