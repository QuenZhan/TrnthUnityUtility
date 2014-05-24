using UnityEngine;
using System.Collections;
public class DespawnTarget : TRNTH.PoolBase {
	public GameObject targetToDespawn;
	public float delay;
	public void excute(){
		enabled=false;
		Despawn(targetToDespawn.transform,delay);
	}
	public override void Awake(){
		base.Awake();
		if(!targetToDespawn)targetToDespawn=gameObject;
	}
	void OnEnable(){
		excute();
	}
}
