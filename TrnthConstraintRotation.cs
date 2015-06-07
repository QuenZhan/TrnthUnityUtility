using UnityEngine;
using System.Collections;

public class TrnthConstraintRotation : TrnthConstraint {
	public Transform rotation;
	public override void setup(){
		base.setup();
		var variable=GetComponent<TrnthVariable>();
		if(variable)rotation=variable.read<Transform>();
	}
	public override void update () {
		// base.update();
		if(!rotation)setup();
		target.rotation=rotation.rotation;
		// target.position=position.position;
	}
}
