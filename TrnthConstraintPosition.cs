using UnityEngine;
using System.Collections;

public class TrnthConstraintPosition : TrnthConstraint {
	public Transform position;
	public override void update () {
		base.update();
		// if(!position)setup();
		if(position)target.position=position.position;
	}
}
