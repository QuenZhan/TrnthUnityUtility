using UnityEngine;
using TRNTH;
public class TrnthFxCurve:TrnthFx{
	public AnimationCurve curve;
	public override void start(){
		base.start();
		var keys=curve.keys;
		var lastkey=keys[keys.Length-1];
		Invoke("end",lastkey.time);
	}
	protected virtual float curveValue{get{return curve.Evaluate(Time.time-_timeStart)+Random.value*noise;}}
}