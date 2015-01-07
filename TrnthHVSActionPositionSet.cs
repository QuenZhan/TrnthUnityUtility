using UnityEngine;
using System.Collections;

public class TrnthHVSActionPositionSet : TrnthHVSAction {
	public Transform target;
	// public UnityEngine.Space space=Space.Self;
	public Vector3 pos;
	public Transform posWorld;
	public Vector3 noise;
	protected override void _execute(){
		var pos=this.pos+noise*Random.value;
		target.localPosition=pos;
		// switch(space){
		// case Space.Self:
		// 	break;
		// case Space.World:
		// 	target.position=pos;
		// 	break;
		// }
		if(posWorld)target.position=posWorld.position+noise*Random.value;
	}
}
