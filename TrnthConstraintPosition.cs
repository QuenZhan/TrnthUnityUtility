using UnityEngine;
using System.Collections;
using System;
public class TrnthConstraintPosition : TrnthConstraint {
	public Transform position;
	public event Action<TrnthConstraintPosition> onLosingPosition=delegate{};
	public override void update () {
		// base.update();
		// if(!position)setup();
		if(position)target.position=position.position;
		else {
			enabled=false;
			onLosingPosition(this);
		}
	}
}
