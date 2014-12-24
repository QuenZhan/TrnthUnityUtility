using UnityEngine;
using System.Collections;

public class TrnthFSMTransform : TrnthFSM {
	public virtual bool transit(Component state){
		foreach(Transform e in transform){
			e.gameObject.SetActive(this.state==state);
		}
		return base.transit(state);
	}
}
