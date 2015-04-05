using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAttackReceiver :  TrnthHVSCondition {

	public float damage{get;private set;}
	public float hpBeforeHit{get;private set;}
	public TrnthAttack attack{get;private set;}
	public TrnthRadio hp;
	public Transform direction;
	// public TrnthHVSAction knockback;
	// public TrnthHVSAction toHurt;
	// public TrnthHVSAction toDie;
	public TrnthHVSCondition onHurt;
	public TrnthHVSCondition onDie;
	public TrnthHVSCondition onKnockback;
	// public TrnthSpawnBoucingNumber spawner;
	public bool persistent;
	// public override string extraMsg{get{return }}
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
