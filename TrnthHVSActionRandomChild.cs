using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// using System.Linq;
using TRNTH;

public class TrnthHVSActionRandomChild : TrnthHVSAction {
	public Transform target;
	public override string extraMsg{get{return "Activation";}}
	protected override void _execute(){
		base._execute();
		var list=new List<Transform>();
		foreach(Transform e in transform){
			list.Add(e);
		}
		var theChild=list.choose();
		TrnthFSM.transit(theChild);
	}
}
