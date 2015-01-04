using UnityEngine;
using System.Collections;
[RequireComponent(typeof(TrnthHVSActionFSMTransformTransit))]
public class TrnthFSMTransform : TrnthFSM {
	public bool activeToggle=true;
	public override bool transit(Component state){
		if(activeToggle){
			foreach(Transform e in transform){
				e.gameObject.SetActive(e==state);
			}			
		}
		return base.transit(state);
	}
}
