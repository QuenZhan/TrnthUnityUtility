using UnityEngine;
using System.Collections;

public class TrnthCallMethod : TrnthTriggerBase {
	public GameObject target;
	public string findTarget;
	public string methodName;
	public override void execute(){
		if(target.activeInHierarchy)target.SendMessage(methodName);
	}
	void Awake(){
		if(target)return;
		var go=GameObject.Find(findTarget);
		target=go;
	}
}
