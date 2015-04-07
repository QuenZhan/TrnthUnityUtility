using UnityEngine;
using System.Collections;

public class TrnthFxCurvePosition : TrnthFxCurve {
	public Transform target;
	public TrnthHVSCondition onEnd;
	public override void start(){
		base.start();
		_pos=transform.position;
	}
	protected override void update(){
		base.update();
		transform.position=Vector3.Lerp(_pos,target.position,curveValue);
	}
	protected override void end(){
		base.end();
		if(onEnd)onEnd.send();
	}
	Vector3 _pos;
}
