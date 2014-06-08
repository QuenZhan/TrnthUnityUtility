using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthCreature:TRNTH.MonoBehaviour{
	public GameObject root;
	public GameObject targetPersitant;
	public TrnthAntenna aStand;
	public bool isVital=true;
	public float scaleGravity=1;
	public float speedMoveMax=3f;
	public float speedMoveTimeToMax=2;
	public float stepMin=0.4f;
	public Vector3 vecForce;
	// public CollisionFlags flag;
	public void jump(float force){
		vecForce.y=force;
	}
	public float rateFall{get{		
		return vecForce.y/10;
	}}
	public float walkRate{
		get{
			var vec=new Vector3(vecForce.x,0,vecForce.z);
			return vec.magnitude/speedMoveMax;
		}
	}
	public void stand(){
		fWalk=0;
		vecForce.x*=0.69f;
		vecForce.z*=0.69f;
	}
	public void lookAt(Vector3 pos){
	}
	public virtual void lookAt(Vector3 pos,float dt){
	}
	public void walkTo(GameObject gobj){
		walk(gobj.transform.position);	
	}
	public void walk(Vector3 posTarget){
		Vector3 dvec=posTarget-transform.position;
		var dt=Time.deltaTime;
		if(dvec.magnitude<stepMin){
			stand();
			return;
		}
		float force=(speedMoveMax/speedMoveTimeToMax)*dt;
		fWalk+=force;
		if(fWalk>=speedMoveMax)fWalk=speedMoveMax;
		dvec=dvec.normalized*fWalk;
		vecForce.x=dvec.x;
		vecForce.z=dvec.z;
	}
	protected Vector3 dirTarget=Vector3.zero;
	public override void Awake(){
		base.Awake();
	}
	float fWalk;
	void OnSpawned(){
		root.transform.localPosition=Vector3.zero;
		vecForce=Vector3.zero;
	}
}
