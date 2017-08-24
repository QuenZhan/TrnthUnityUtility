using UnityEngine;
using TRNTH;
public class TrnthFxCurve:TrnthFx{
	public AnimationCurve curve;
	public float duration{get{
		var keys=curve.keys;
		if(keys.Length<1)return 0;
		var lastkey=keys[keys.Length-1];
		return lastkey.time;
	}}
	public override void start(){
		base.start();
		Invoke("end",duration);
	}
	protected virtual float curveValue{get{return curve.Evaluate(Time.time-_timeStart)+Random.value*noise;}}
}