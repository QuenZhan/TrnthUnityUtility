using UnityEngine;
using System.Collections;

public class DespawnTarget : TRNTH.MonoBehaviour {
	public GameObject targetToDespawn;
	public float delay;
	public void excute(){
		enabled=false;
		Despawn(targetToDespawn.transform,delay);
	}
	void Awake(){
		base.Awake();
		if(!targetToDespawn)targetToDespawn=gameObject;
	}
	void OnEnable(){
		excute();
	}
}
