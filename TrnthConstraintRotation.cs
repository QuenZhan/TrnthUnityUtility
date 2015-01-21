using UnityEngine;
using System.Collections;

public class TrnthConstraintRotation : TrnthConstraint {
	public Transform rotation;
	void Update(){
		target.rotation=rotation.rotation;
	}
}
