using UnityEngine;
using System.Collections;

public class TrnthHVSActionRigidForcer : TrnthHVSAction,ITrnthForcer {
	public Rigidbody rigid;
	public Vector3 forceInit;
	public Vector3 noise;
	protected override void _execute(){
		rigid.velocity=forceInit+(new Vector3(Random.value*noise.x,Random.value*noise.y,Random.value*noise.z));
	}
	public void addForce(Vector3 vec){
		forceInit=vec;
		_execute();
	}
}
