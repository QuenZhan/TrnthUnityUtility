using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAttackReceiver :  TrnthHVSCondition {

	public float damage{get;private set;}
	public float hpBeforeHit{get;private set;}
	public TrnthAttack attack{get;private set;}
	public TrnthRadio hp;
	public Transform direction;
	public TrnthHVSCondition onHurt;
	public TrnthHVSCondition onDie;
	public TrnthHVSCondition onKnockback;
	public bool persistent;
	public virtual void hurtWith(TrnthAttack attack,TrnthHVSActionPhysicsCast physicsCast){
		// Debug.Log("dsfs");
		this.attack=attack;
		damage=attack.damage;
		hpBeforeHit=hp.value;
		if(direction){
			direction.transform.position=transform.position;
			direction.LookAt(attack.transform);
		}
		conditionSend();
		hp-=damage;
		if(persistent&&hp.value>1)hp.value=1;

		hp.clamp();
		attack.react(damage);
		// send();
		log();
	}
	public virtual void conditionSend(){
		var isDead=damage>hp.value;
		if(persistent)isDead=damage>hp.value&&hp.rate==0;
		if(isDead){
			// if(toDie){
			// 	toDie.execute();
			// }
			if(onDie)onDie.send();
		}else{
			if(attack.knockback){
				// if(knockback)knockback.execute();
				if(onKnockback)onKnockback.send();
			}else{
				// if(toHurt)toHurt.execute();
				if(onHurt)onHurt.send();			
			}
		}
	}

}
