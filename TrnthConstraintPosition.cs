using UnityEngine;
using System.Collections;

public class TrnthConstraintPosition : TrnthConstraint {
	public Transform position;
	void Update () {
		target.position=position.position;
	}
}
