using UnityEngine;
using System.Collections;

public class TrnthConstraintFletching : MonoBehaviour {
	public Rigidbody rig;
	public bool is2d;
	void Update(){
		// var vecUp=Vector3.up;
		if(is2d){
			var vec=rig.velocity;
			vec.z=0;
			// if(vec.x==0)vec.x=0.001f;
			// var value=vec.x!=0?(vec.y/vec.x):(Mathf.Infinity);
			// if(vec.x==0)
			var angle=Vector3.Angle(Vector3.up,vec);
			if(vec.x>0)angle*=-1;
			transform.eulerAngles=Vector3.forward*angle;
			// vecUp=Vector3.right;
			return;
		}
		transform.LookAt(transform.position+rig.velocity);
	}
}
