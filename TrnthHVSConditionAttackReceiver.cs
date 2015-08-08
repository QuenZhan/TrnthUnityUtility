using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAttackReceiver :  TrnthHVSCondition {
	public float damage{get;private set;}
	public float hpBeforeHit{get;private set;}
	public HurtResult result;
	[SerializeField]public TrnthRadio hp;
	[SerializeField]public Transform direction;
	[SerializeField]public bool persistent;
	[HideInInspector]public TrnthHVSCondition onHurt;
	[HideInInspector]public TrnthHVSCondition onDie;
	[HideInInspector]public TrnthHVSCondition onKnockback;
	public void hurtWith(TrnthAttack attack,TrnthHVSActionPhysicsCast physicsCast){
		// this.attack=attack;
		damage=attack.damage;
		var hpValue=hp.value;
		hpValue-=damage;
		if(hpValue<0)hpValue=0;
		if(persistent&&hpBeforeHit>1&&hpValue<1)hpValue=1;
		result=new HurtResult(){hp=(int)hpValue
			,lookAt=attack.transform.position
			,randomSeed=Random.value
			,force=attack.knockback?1:0
			,damage=damage
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
		public int hp;
		public int damage;
		public Vector3 lookAt;
		public float randomSeed;
		public float force;
		public bool showDamage;
		public string control;
	}
}
