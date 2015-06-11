using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAttackReceiver :  TrnthHVSCondition {

	public float damage{get;private set;}
	public float hpBeforeHit{get;private set;}
	public TrnthHVSActionAttackSender attack{get;private set;}
	public TrnthRadio hp;
	public Transform direction;
	public bool persistent;
	public virtual void hurtWith(TrnthHVSActionAttackSender attack,System.Action<TrnthHVSConditionAttackReceiver> react){
		this.attack=attack;
		damage=attack.damage;
		hpBeforeHit=hp.value;
		if(direction){
			direction.transform.position=transform.position;
			direction.LookAt(attack.direction.transform);
		}
		hp-=damage;
		if(persistent&&hpBeforeHit>1&&hp.value<1)hp.value=1;
		hp.clamp();
		react(this);
		send();
	}
}
