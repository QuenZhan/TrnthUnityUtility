using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAttackReceiver :  TrnthHVSCondition {
	// [SerializeField]protected DSShell shell;
	public float damage{get;private set;}
	public float hpBeforeHit{get;private set;}
	public HurtResult result;
	// public TrnthAttack attack{get;private set;}
	[SerializeField]public TrnthRadio hp;
	public Transform direction;
	[HideInInspector]public TrnthHVSCondition onHurt;
	[HideInInspector]public TrnthHVSCondition onDie;
	[HideInInspector]public TrnthHVSCondition onKnockback;
	public bool persistent;
	public void hurtWith(TrnthAttack attack,TrnthHVSActionPhysicsCast physicsCast){
		// this.attack=attack;
		damage=attack.damage;
		var hpValue=hp.value;
		hpValue-=damage;
		if(hpValue<0)hpValue=0;
		if(persistent&&hpBeforeHit>1&&hpValue<1)hpValue=1;
		var result=new HurtResult(){hp=hpValue
			,lookAt=attack.transform.position
			,randomSeed=Random.value
			,force=attack.knockback?1:0
			,showDamage=attack.showDamage
		};
		hurtResult(result,attack);
		attack.react(damage);
	}
	public virtual void hurtResult(HurtResult result,TrnthAttack attack){
		hurtExecute(result);
	}
	public void hurtExecute(HurtResult result){
		if(direction){
			direction.transform.position=transform.position;
			direction.LookAt(result.lookAt);
		}
		conditionSend(result);
		hpBeforeHit=this.hp.value;
		// var damage=this.hp.value - result.hp;
		this.hp.value=result.hp;
		send();
		log();
	}
	public virtual void conditionSend(HurtResult result){
		var isDead=damage>hp.value;
		if(persistent)isDead=damage>hp.value&&hp.rate==0;
		if(isDead){
			if(onDie)onDie.send();
		}else{
			if(result.force>0){
				if(onKnockback)onKnockback.send();
			}else{
				if(onHurt)onHurt.send();
			}
		}
	}
	public struct HurtResult{
		public float hp;
		public Vector3 lookAt;
		public float randomSeed;
		public float force;
		public bool showDamage;
	}
}
