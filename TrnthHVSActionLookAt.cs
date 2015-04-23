using UnityEngine;
using System.Collections;
// [ExecuteInEditMode]
public class TrnthHVSActionLookAt : TrnthHVSAction {
	public Transform self;
	public Transform target;
	// public string findTarget;
	public bool yOnly=false;
	// public bool everyFrame=true;
	protected override void _execute(){
		if(!target)return;
		var vec=target.position;
		if(yOnly)vec.y=self.position.y;
		self.LookAt(vec);
	}
	// void find(){
	// 	var go=GameObject.Find(findTarget);
	// 	if(go)target=go.transform;
	// }
}
