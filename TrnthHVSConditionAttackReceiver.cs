using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAttackReceiver :  TrnthHVSCondition {
	public TrnthRadio hp;
	public Transform direction;
	public bool persistent;

	public float damage{get;private set;}
	public float hpBeforeHit{get;private set;}
	public ITrnthAttack attack{get;private set;}
	public virtual void hurtWith(ITrnthAttack attack,System.Action<TrnthHVSConditionAttackReceiver> react){
		this.attack=attack;
		damage=attack.damage;
		hpBeforeHit=hp.value;
		if(direction){
			direction.transform.position=transform.position;
			direction.LookAt(attack.worldOrigin);
		}
		hp-=damage;
		if(persistent&&hpBeforeHit>1&&hp.value<1)hp.value=1;
		hp.clamp();
		react(this);
		send();
	}
}
