using UnityEngine;
using System.Collections;

public class TrnthFxCurveScale : TrnthFxCurve {
	public Transform target;
	public bool fromNowValue=true;
	public override void start(){
		base.start();
		if(fromNowValue){
			_rate=target.localScale.magnitude/curveValue;
		}else{
			_rate=1;
		}
	}
	protected override void update(){
		base.update();
		target.localScale=Vector3.one*curveValue*_rate;
	}
	float _rate;
}
