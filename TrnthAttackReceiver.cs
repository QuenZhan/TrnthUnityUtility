using UnityEngine;
using System.Collections;

public class TrnthAttackReceiver : TrnthHVSCondition {
	public TrnthRadio hp;
	internal TrnthAttack from;
	public Transform direction;
	public TrnthHVSAction knockback;
	public TrnthHVSAction toHurt;
	public TrnthHVSAction toDie;
	public TrnthHVSCondition onHurt;
	public TrnthHVSCondition onDie;
	public TrnthHVSCondition onKnockback;
	public TrnthSpawnBoucingNumber spawner;
	public bool persistent;
	public virtual void hurtWith(TrnthAttack attack){
		from=attack;
		var damage=attack.damage;
		var crit=attack.showDamage;
		var _hp=hp.rate;
		hp-=damage;
		hp.clamp();
		attack.react(damage);
		if(spawner&&crit&&damage>=1){
			spawner.damage=(int)Mathf.Ceil(damage);
			spawner.execute();
		}
		if(direction){
			direction.transform.position=transform.position;
			direction.LookAt(attack.transform);
		}
		if(attack.knockback){
			if(knockback)knockback.execute();
			if(onKnockback)onKnockback.send();
		}else{
			if(toHurt)toHurt.execute();
			if(onHurt)onHurt.send();
		}
		var isDead=hp.rate<=0;
		// Debug.Log(hp.rate,attack);
		if(persistent)isDead=hp.rate<=0&&_hp<=0;
		if(isDead){
			if(toDie){
				toDie.execute();
			}
			if(onDie)onDie.send();
		}
		send();
	}
}
