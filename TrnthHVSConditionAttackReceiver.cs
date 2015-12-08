using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAttackReceiver :  TrnthHVSCondition {
	public virtual void hurtWith(IDSTeamReport report,ITrnthAttackOffensive attack){;}
	public void hurtResult(HurtResult result,TrnthAttack attack){;}
	public void hurtExecute(HurtResult result){
	}
	public virtual void conditionSend(HurtResult result){
	}
	public struct HurtResult{
		public int hp;
		public int damage;
		public Vector3 lookAt;
		public float randomSeed;
		public float force;
		public bool showDamage;
		public string control;
	}
}
