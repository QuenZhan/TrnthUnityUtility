using UnityEngine;
using System.Collections;

public class TrnthHVSActionDestroy : TrnthHVSAction {
	public GameObject target;
	protected override void _execute(){
		Destroy(target);
	}
}
