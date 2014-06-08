using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthCreatureRigidbody:TrnthCreature{
	public Rigidbody rig;
	public TrnthAntenna aGrounded;
	void FixedUpdate(){
		float dt=Time.deltaTime;
		if(isVital){
			if(targetPersitant){
				walkTo(targetPersitant);
			}else stand();			
		}
		vecForce+=Physics.gravity*dt*scaleGravity;
		vecForce.y*=0.97f;
		// if(!aGrounded.isTriggerStay){
		// }
		// else 
			if(vecForce.y<0)vecForce.y=0;
		Vector3 vec=vecForce*dt;
		// vec.y=rig.velocity.y;
		// rig.MovePosition(rig.transform.position+vec);
		// rig.AddForce(vecForce/dt);
		rig.velocity=vec/dt;
		// rig.AddForce(vec/dt*10f);
	}
}
