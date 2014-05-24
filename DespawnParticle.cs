using UnityEngine;
using System.Collections;

public class DespawnParticle : TRNTH.MonoBehaviour {
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
