using UnityEngine;
using System.Collections;

public class TrnthAttackReceiver : TrnthHVSCondition {
	public TrnthRadio hp;
	internal TrnthAttack from;
	public Transform direction;
	public TrnthHVSAction knockback;
	public TrnthHVSAction toHurt;
	public TrnthHVSAction toDie;
	public TrnthSpawnBoucingNumber spawner;
	public float cooldown=0;
	// public float damage
	public virtual void hurtWith(TrnthAttack attack){
		if(!a.a)return;
		from=attack;
		a.s=cooldown;
		var damage=attack.damage;
		var crit=attack.showDamage;
		hp-=damage;
		attack.react(damage);
		if(spawner&&crit){
			spawner.damage=(int)damage;
			spawner.execute();
		}
		if(direction){
			direction.transform.position=transform.position;
			direction.LookAt(attack.transform);
		}
		if(attack.knockback){
			if(knockback)knockback.execute();
		}else{
			if(toHurt)toHurt.execute();
		}
		if(hp.rate<0){
			if(toDie){
				toDie.execute();
			}
		}
	}
	TrnthAlarm a=new TrnthAlarm();
}
