using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAttackReceiver :  TrnthHVSCondition {
	// [SerializeField]protected DSShell shell;
	public float damage{get;private set;}
	public float hpBeforeHit{get;private set;}
	public TrnthAttack attack{get;private set;}
	public TrnthRadio hp;
	public Transform direction;
	[HideInInspector]public TrnthHVSCondition onHurt;
	[HideInInspector]public TrnthHVSCondition onDie;
	[HideInInspector]public TrnthHVSCondition onKnockback;
	public bool persistent;
	public void hurtWith(TrnthAttack attack,TrnthHVSActionPhysicsCast physicsCast){
		this.attack=attack;
		damage=attack.damage;
		var hpValue=hp.value;
		hpValue-=damage;
		if(hpValue<0)hpValue=0;
		if(persistent&&hpBeforeHit>1&&hpValue<1)hpValue=1;
		hurtResult(hpValue,attack.transform.position,Random.value);
	}
	public virtual void hurtResult(float hp,Vector3 lookAt,float randomSeed){
		hurtExecute(hp,lookAt,randomSeed);
	}
	public void hurtExecute(float hp,Vector3 lookAt,float randomSeed){
		if(direction){
			direction.transform.position=transform.position;
			direction.LookAt(lookAt);
		}
		conditionSend();
		hpBeforeHit=this.hp.value;
		var damage=this.hp.value - hp;
		this.hp.value=hp;
		attack.react(damage);
		send();
		log();
	}
	public virtual void conditionSend(){
		var isDead=damage>hp.value;
		if(persistent)isDead=damage>hp.value&&hp.rate==0;
		if(isDead){
			if(onDie)onDie.send();
		}else{
			if(attack.knockback){
				if(onKnockback)onKnockback.send();
			}else{
				if(onHurt)onHurt.send();
			}
		}
	}
	

}
