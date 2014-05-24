using UnityEngine;
using System.Collections;
using TRNTH;
public class InvisibleToDespawn : PoolBase {
	public GameObject target;
	public float delay;
	public void excute(){
		if(!a.a)return;
		Despawn(target.transform);
	}
	Alarm a=new Alarm();
	void Start(){
		a.s=delay;
	}
	void OnBecameInvisible(){
		excute();
	}
	void OnEnabled(){
		Start();
	}
	void OnSpawned(){
		Start();		
	}
}
