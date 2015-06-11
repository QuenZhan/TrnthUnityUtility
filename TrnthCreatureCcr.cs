using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthCreatureCcr:TrnthCreature{
	public CharacterController ccr;
	public override Transform traSelf{get{return ccr.transform;}}
	public bool walkInTheAir;
	void Update(){
		float dt=Time.deltaTime;
		if(walkInTheAir||ccr.isGrounded){
			if(targetPersitant)walkTo(targetPersitant);
		}
		if(!ccr.isGrounded){
			vecForce+=Physics.gravity*dt*scaleGravity;
		}
		Vector3 vec=vecForce*dt;
		positionDelta=traSelf.position;
		if(lookAt){
			var vecHorizon=vec;
			vecHorizon.y=0;
			ccr.transform.LookAt(ccr.transform.position+vecHorizon);
		}
		var flag=ccr.Move(vec);
		if ((flag & CollisionFlags.Above) != 0
			&&vecForce.y>0)vecForce.y=0;
		positionDelta=traSelf.position-positionDelta;
	}
}
