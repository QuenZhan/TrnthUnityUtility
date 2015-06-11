using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// using System.Linq;
using TRNTH;

public class TrnthHVSActionActivateToggle : TrnthHVSAction {
	public GameObject target;
	protected override void _execute(){
		target.SetActive(!target.activeSelf);
	}
}
