using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TRNTH;

public class TrnthHVSActionRandomChild : TrnthHVSAction {
	public Transform target;
	protected override void _execute(){
		var list=new List<Transform>();
		foreach(Transform e in target){
			list.Add(e);
		}
		var theChild=list.choose();
		TrnthFSM.transit(theChild);
	}
}
