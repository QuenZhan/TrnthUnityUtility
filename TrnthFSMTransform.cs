using UnityEngine;
using System.Collections;

public class TrnthFSMTransform : TrnthFSM {
	public override bool transit(Component state){
		foreach(Transform e in transform){
			e.gameObject.SetActive(e==state);
		}
		return base.transit(state);
	}
}
