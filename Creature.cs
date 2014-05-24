using UnityEngine;
using System.Collections;
namespace TRNTH{
// [RequireComponent (typeof (CharacterController))]
public class Creature:TRNTH.MonoBehaviour{
	public bool isGravity=true;
	public bool isVital=true;
	public bool onlyJumpWhileGrounded=true;
	public float speedMoveForce=0.1f;
	public float speedMoveMax=3f;
	public float fJump=7f;
	public float lookRate=0.03f;
	public float lookDisMin=0.9f;
	public float cdJump=0.2f;
	public float disWalkThreshold=0.9f;
	public Vector3 vecForce;
	public Animator animator;
	float fWalk=0.0f;
	public float walkRate{
		get{
			var vec=new Vector3(vecForce.x,0,vecForce.z);
			return vec.magnitude/speedMoveMax;
		}
	}
	public void play(string str){
		StartCoroutine(parameterOnce(str));
	}
	public void stand(){
		vecForce.x*=0.69f;
		vecForce.z*=0.69f;
	}
	public void lookAt(Vector3 pos){
		lookAt(pos,lookRate);
	}
	public virtual void lookAt(Vector3 pos,float dt){
		if(U.dVecY(pos,this.pos).magnitude<lookDisMin)return;
		Transform tra=transform;
		dirTarget=Vector3.Slerp(dirTarget,(new Vector3(pos.x,tra.position.y,pos.z)-tra.position).normalized,dt*6);
		ccr.transform.LookAt(tra.position+dirTarget);
		var vec=ccr.transform.eulerAngles;
		vec.x=0;
		ccr.transform.eulerAngles=vec;
	}
	public void walkTo(GameObject gobj){
		walk(gobj.transform.position);	
	}
	public void walk(Vector3 posTarget){
		// if((posTarget-pos).magnitude<disWalkThreshold){
		// 	stand();
		// 	return;
		// }
		Vector3 dvec=posTarget-transform.position;
		dvec.Normalize();
		fWalk+=speedMoveForce;
		Mathf.Clamp(fWalk,0,speedMoveMax);
		dvec*=speedMoveMax;
		vecForce.x=dvec.x;
		vecForce.z=dvec.z;
	}
	public void attack(){
		if(!aCdAttack.a)return;
		aCdAttack.s=0.2f;
		aPreAttack.s=0.12f;
		sur="atk";
		StartCoroutine(parameterOnce("atk"));
	}
	public void jump(){
		if(!aCdJump.a)return;
		if(onlyJumpWhileGrounded&&!ccr.isGrounded)return;
		vecForce+=Vector3.up*fJump;
		aCdJump.s=cdJump;
	}
	public CharacterController ccr;
	protected Vector3 dirTarget=Vector3.zero;
	Alarm aLook=new Alarm();
	Alarm aCdJump=new Alarm();
	Alarm aCdAttack=new Alarm();
	Alarm aPreAttack=new Alarm();
	string sur="";
	// Alarm aAir=new Alarm();
	// Vector3 prePos;
	IEnumerator parameterOnce(string str){
		if(animator){
			animator.SetBool(str,true);
			yield return new WaitForSeconds(0);
			// if(!this)return false;
			animator.SetBool(str,false);
		}
	}
	public override void Awake(){
		base.Awake();
		if(!ccr)ccr=GetComponent<CharacterController>();
		if(!animator){
			foreach(Transform e in transform){
				var ani=e.GetComponent<Animator>();
				if(ani)animator=ani;
			}
		}
	}
	public virtual void FixedUpdate(){
		float dt=Time.deltaTime;
		fWalk*=0.9f;
		if(isGravity&&!ccr.isGrounded){
			vecForce+=Physics.gravity*dt;
			vecForce.y*=0.97f;
		}
		Vector3 vec=vecForce*dt;
		ccr.Move(vec);
	}
	public virtual void Update(){}
}
}
