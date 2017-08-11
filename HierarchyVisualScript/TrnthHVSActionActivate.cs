using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthHVSActionActivate : TrnthHVSAction {
	public bool on=true;
	public GameObject target;
	protected override void _execute(){
		target.SetActive(on);
	}
}
