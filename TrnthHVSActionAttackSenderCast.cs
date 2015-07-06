using UnityEngine;
using System.Collections;

public class TrnthHVSActionAttackSenderCast : TrnthHVSActionAttackSender {
	[SerializeField] TrnthHVSActionPhysicsCast pc;
	protected override Collider[] colliders{get{return pc.colliders;}}

}
