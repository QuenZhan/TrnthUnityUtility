using UnityEngine;
using System.Collections;
using TRNTH;
public abstract class TrnthCreature:TrnthMonoBehaviour{
	public abstract Transform traSelf{get;}
	public GameObject targetPersitant;
	public bool lookAt=true;
	public float scaleGravity=1;
	public float speedMoveMax=3f;
	public float speedMoveTimeToMax=0.1f;
	public float stepMin=0.4f;
	public Vector3 vecForce;
	public Vector3 positionDelta{get;protected set;}
	public float speedNow{get{return fWalk;}}
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
		vecForce.x*=0;
		vecForce.z*=0;
	}
	public void walkTo(GameObject gobj){
		walk(gobj.transform.position);	
	}
	public void walk(Vector3 posTarget){
		Vector3 dvec=posTarget-traSelf.position;
		dvec.y=0;
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
		vecForce=Vector3.zero;
	}
	void OnDisable(){
		vecForce*=0;
	}
}
