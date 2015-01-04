using UnityEngine;
using System.Collections;

public class TrnthHVSActionCallMethod : TrnthHVSAction {
	public string findTarget;
	public GameObject target;
	public string methodName;
	public void find(){
		if(target)return;
		var go=GameObject.Find(findTarget);
		target=go;
	}
	protected override void _execute(){
		base._execute();
		if(!target)find();
		if(target.activeInHierarchy)target.SendMessage(methodName);
	}
}
