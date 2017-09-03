using UnityEngine;
using System.Collections;

public class TrnthConstraintPositionLerp : TrnthConstraintPosition {
	[SerializeField]float rate=0.2f;
	protected override Vector3 posUpdate{get{return Vector3.Lerp(target.position,position.position,rate);}}
}
