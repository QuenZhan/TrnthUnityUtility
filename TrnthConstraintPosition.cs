using UnityEngine;
using System.Collections;

public class TrnthConstraintPosition : TrnthConstraint {
	public Transform position;
	public override void setup(){
		base.setup();
		// var variable=GetComponent<TrnthVariable>();
		// if(variable)position=variable.read<Transform>();
	}
	public override void update () {
		base.update();
		if(!position)setup();
		target.position=position.position;
	}
}
