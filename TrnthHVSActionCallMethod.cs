using UnityEngine;
using System.Collections;

public class TrnthHVSActionCallMethod : TrnthHVSAction {
	public GameObject target;
	public string findTarget;
	public string methodName;
	public void find(){
		if(target)return;
		var go=GameObject.Find(findTarget);
		target=go;
	}
	protected override void _execute(){
		base._execute();
		if(target.activeInHierarchy)target.SendMessage(methodName);
	}
	void Awake(){
		subscribe();
		find();
	}
}
