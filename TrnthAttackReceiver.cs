using UnityEngine;
using System.Collections;

public class TrnthAttackReceiver : MonoBehaviour {
	public TrnthRadio hp;
	public GameObject onDead;
	public GameObject onHit;
	public TrnthSpawn spawner;
	public float cooldown=0;
	public void hurtWith(TrnthAttack attack){
		if(!a.a)return;
		a.s=cooldown;		
		hp-=attack.damage;
		var instance=spawner.execute();
		var bn=instance.GetComponent<TrnthBoucingNumber>();
		bn.setup((int)attack.damage);
		// instance.GetComponent<
		if(onHit)onHit.SetActive(true);
		if(hp.rate<0){
			if(onDead)onDead.SetActive(true);
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
