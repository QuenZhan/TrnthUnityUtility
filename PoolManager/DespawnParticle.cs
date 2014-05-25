using UnityEngine;
using System.Collections;
using TRNTH;
public class DespawnParticle : DespawnTarget {
	public ParticleSystem ps;
	public ParticleEmitter emitter;
	public bool emitOnSpawned=true;
	public override void excute(){
		execute();	
	}
	public override void execute(){
		if(ps)ps.enableEmission=false;
		if(emitter){
			emitter.emit=false;
			Debug.Log("ddd");
		}
		base.execute();
		//Despawn(targetToDespawn.transform,5);
	}
	public override void OnSpawned(){
		base.OnSpawned();
		if(emitOnSpawned){
			if(ps)ps.enableEmission=true;
			if(emitter)emitter.emit=true;
		}
	}
}
