using UnityEngine;
using System.Collections;
using TRNTH;
public class DespawnParticle : PoolBase {
	public ParticleSystem ps;
	public GameObject targetToDespawn;
	public bool emitOnSpawned=true;
	public void excute(){
		ps.enableEmission=false;
		Despawn(targetToDespawn.transform,5);
	}
	void OnSpawned(){
		if(emitOnSpawned)ps.enableEmission=true;
	}
}
