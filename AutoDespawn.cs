using UnityEngine;
using System.Collections;
namespace TRNTH{
public class AutoDespawn : MonoBehaviour {
	public ParticleSystem ps;
	public ParticleEmitter emiiter;
	public Transform target;
	private int count=1;
	Alarm a=new Alarm();
	void excute(){
		Despawn(target);
		// enabled=false;
	}
	void Awake(){
		if(!ps)ps=GetComponent<ParticleSystem>();
		if(!emiiter)emiiter=GetComponent<ParticleEmitter>();
		if(!target)target=transform;
	}
	void Update(){
		if(!a.a)return;
		// return;
		int num=0;
		if(emiiter){
			num=emiiter.particleCount;
			if(num==0)excute();
		}
		if(ps&&!ps.IsAlive())excute();
		//if(num>count)count=num;
	}
	void OnSpawned(){
		a.s=0.2f;
	}
}
}