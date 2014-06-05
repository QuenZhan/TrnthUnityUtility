using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthCreatureCcr:TrnthCreature{
	public CharacterController ccr;
	public bool walkInTheAir;
	void FixedUpdate(){
		float dt=Time.deltaTime;
		if(isVital){
			if(walkInTheAir||ccr.isGrounded){
				if(targetPersitant){
					walkTo(targetPersitant);
					if(lookAtTarget)lookAt(targetPersitant.transform.position);
				}else stand();			
				
			}
		}
		if(!ccr.isGrounded){
			vecForce+=Physics.gravity*dt*scaleGravity;
			vecForce.y*=0.97f;
		}
		Vector3 vec=vecForce*dt;
		ccr.Move(vec);
	}
}
