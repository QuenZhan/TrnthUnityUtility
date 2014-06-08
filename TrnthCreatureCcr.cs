using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthCreatureCcr:TrnthCreature{
	public CharacterController ccr;
	public bool walkInTheAir;
	void FixedUpdate(){
		float dt=Time.deltaTime;
		bool isStand=(aStand&&aStand.isTriggerStay)
			||!targetPersitant
			||!targetPersitant.activeInHierarchy;
		if(walkInTheAir||ccr.isGrounded){
			if(!isStand)walkTo(targetPersitant);
			else stand();
		}
		if(!ccr.isGrounded){
			vecForce+=Physics.gravity*dt*scaleGravity;
			vecForce.y*=0.97f;
		}
		Vector3 vec=vecForce*dt;
		var flag=ccr.Move(vec);
		if ((flag & CollisionFlags.Above) != 0
			&&vecForce.y>0)vecForce.y=0;

	}
}
