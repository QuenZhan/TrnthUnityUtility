using UnityEngine;
using System.Collections;
using System;
public class TrnthConstraintPosition : TrnthConstraint {
	public Transform position;
	public event Action<TrnthConstraintPosition> onLosingPosition=delegate{};
	public override void update () {
		if(position)target.position=posUpdate;
		else {
			enabled=false;
			onLosingPosition(this);
		}
	}
	protected virtual Vector3 posUpdate{get{return position.position;}}
}
