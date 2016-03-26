using UnityEngine;
using System.Collections;
// [ExecuteInEditMode]
public class TrnthHVSActionLookAt : TrnthHVSAction {
	public Transform self;
	public Transform target;
	public bool yOnly=false;
	protected override void _execute(){
		if(!target)return;
		var vec=target.position;
		if(yOnly)vec.y=self.position.y;
		self.LookAt(vec);
	}
}
