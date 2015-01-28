using UnityEngine;
using System.Collections;

public class TrnthHVSActionSendMessage : TrnthHVSAction {
	public string findTarget;
	public GameObject target;
	public string methodName;
	// public string methodParameter;
	public void find(){
		if(target)return;
		var go=GameObject.Find(findTarget);
		target=go;
	}
	protected override void _execute(){
		base._execute();
		if(!target)find();
		// if(methodParameter=="")methodParameter=null;
		if(target.activeInHierarchy)target.SendMessage(methodName);
	}
}
