using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthCreatureCcr:TrnthCreature{
	public CharacterController ccr;
	// public float fSpacer;
	public bool walkInTheAir;
	void FixedUpdate(){
		float dt=Time.deltaTime;
		// bool isStand=(aStand&&aStand.isTriggerStay)
		// 	||!targetPersitant
			// ||!targetPersitant.activeInHierarchy
			;
		if(walkInTheAir||ccr.isGrounded){
			if(targetPersitant)walkTo(targetPersitant);
			// if(!isStand)walkTo(targetPersitant);
			// else stand();
		}
		if(!ccr.isGrounded){
			vecForce+=Physics.gravity*dt*scaleGravity;
			vecForce.y*=0.97f;
		}
		Vector3 vec=vecForce*dt;
		positionDelta=traSelf.position;
		var flag=ccr.Move(vec);
		if ((flag & CollisionFlags.Above) != 0
			&&vecForce.y>0)vecForce.y=0;
		positionDelta=traSelf.position-positionDelta;
	}
	// void OnControllerColliderHit(ControllerColliderHit hit){
	// 	var vec=-hit.moveDirection;
	// 	vec.y=0;
	// 	vecForce+=vec*fSpacer;
	// 	var creature=hit.gameObject.GetComponent<TrnthCreature>();
	// 	if(creature)creature.vecForce-=vec*fSpacer;
	// }
}
