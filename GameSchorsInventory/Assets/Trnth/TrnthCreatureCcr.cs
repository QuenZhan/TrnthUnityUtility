using UnityEngine;
using System.Collections;
using TRNTH;
[RequireComponent(typeof(CharacterController))]
public class TrnthCreatureCcr:TrnthCreature{
	CharacterController ccr;
	public override Transform traSelf{
		get{
			return _ccrTransform;
		}
	}
	Transform _ccrTransform;
	public override void Awake ()
	{
		base.Awake ();
		ccr=GetComponent<CharacterController>();
		_ccrTransform=ccr.transform;
	}
	public bool walkInTheAir;
	protected virtual void Update(){
		if(!ccr.enabled)return;
		float dt=Time.deltaTime;
		if(walkInTheAir||ccr.isGrounded){
			if(targetPersitant)walkTo(targetPersitant);
		}
		if(!ccr.isGrounded){
			vecForce+=Physics.gravity*dt*scaleGravity;
			vecForce.y*=0.97f;
		}
		Vector3 vec=vecForce*dt;
		positionDelta=traSelf.position;
		if(lookAt){
			var vecHorizon=vec;
			vecHorizon.y=0;
			_ccrTransform.LookAt(_ccrTransform.position+vecHorizon);
		}
		var flag=ccr.Move(vec*timeScale);
		if ((flag & CollisionFlags.Above) != 0
			&&vecForce.y>0)vecForce.y=0;
		positionDelta=traSelf.position-positionDelta;
	}
}
