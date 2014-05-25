using UnityEngine;
using System.Collections;
namespace TRNTH{
public class AutoDespawn : PoolBase {
	public ParticleSystem ps;
	public ParticleEmitter emiiter;
	public Transform target;
	Alarm a=new Alarm();
	void excute(){
		Despawn(target);
	}
	void Start(){
		if(!ps)ps=GetComponent<ParticleSystem>();
		if(!emiiter)emiiter=GetComponent<ParticleEmitter>();
		if(!target)target=transform;
	}
	void Update(){
		if(!a.a)return;
		int num=0;
		if(emiiter){
			num=emiiter.particleCount;
			if(num==0)excute();
		}
		if(ps&&!ps.IsAlive())excute();
		//Debug.Log(ps.IsAlive());
	}
	void OnSpawned(){
		a.s=0.2f;
	}
}
}