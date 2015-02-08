using UnityEngine;
using System.Collections;

public class TrnthFxIndexerRotate : TrnthFxIndexer {
	public float radius=1;
	protected override void _setup(Transform[] children){
		var angle=360f/children.Length;
		var direction=vecDirection;
		for(var i=0;i<children.Length;i++){
			var e=children[i];
			e.localEulerAngles=i*angle*direction;
			e.localPosition=e.forward*radius;
		}
		margin=angle;
	}
	protected override void update(float rate){
		_value+=(index*margin-_value)*rate;
		// var value+=(index*margin-transform.localEulerAngles.magnitude)*rate;
		transform.localEulerAngles=-_value*vecDirection;
	}
	float _value;
}
