using UnityEngine;
using System.Collections;

public class TrnthAttackReceiver : MonoBehaviour {
	public TrnthRadio hp;
	public TrnthAttack from;
	public GameObject onDead;
	public GameObject onHit;
	public Transform direction;
	public TrnthFSMManagerApply knockback;
	public TrnthFSMManagerApply toHurt;
	public TrnthSpawn spawner;
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
			var instance=spawner.execute();
			if(instance){
				var bn=instance.GetComponent<TrnthBoucingNumber>();
				bn.setup((int)damage);
			}
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
		// instance.GetComponent<
		if(onHit){
			onHit.SetActive(true);
		}
		if(hp.rate<0){
			if(onDead){
				onDead.SetActive(true);
				onDead.SetActive(false);
				// onDead.SetActive(false);
			}
		}
	}
	public void hurt(){
		if(!a.a)return;
		a.s=cooldown;
		// Debug.Log("ddd");
		// hp+=-1*60*Time.deltaTime;
		if(onHit)onHit.SetActive(true);
		if(hp.rate<0){
			if(onDead)onDead.SetActive(true);
		}
	}
	TrnthAlarm a=new TrnthAlarm();
	void OnSpawned(){
		hp.toggle=(true);
	}
}
