using UnityEngine;
using System.Collections;

public class TrnthHVSActionAttackSenderCollider : TrnthHVSActionAttackSender {
	[SerializeField] TrnthHVSConditionCollider conditionCollider;
	protected override Collider[] colliders{get{return new Collider[]{conditionCollider.GetComponent<Collider>()};}}
}
