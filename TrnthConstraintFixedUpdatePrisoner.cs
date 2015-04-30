using UnityEngine;
using System.Collections;

public class TrnthConstraintFixedUpdatePrisoner : TrnthConstraintFixedUpdate {
	public float left=-10000;
	public float right=10000;

	public override void update(Vector3 pos){
		// var pos=target.position;
		if(pos.x>right)pos.x=right;
		if(pos.x<left)pos.x=left;
		base.update(pos);
	}
}
