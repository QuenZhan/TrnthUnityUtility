using UnityEngine;
using System.Collections;

public class TrnthHVSActionPositionAdd : TrnthHVSAction {
	public Transform tra;
	public Vector3 add;
	public Vector3 noise;
	protected override void _execute(){
		base.execute();
		tra.position=tra.position+add
			+Vector3.up*noise.y*Random.value
			+Vector3.right*noise.x*Random.value
			+Vector3.forward*noise.z*Random.value
			;
	}
}
