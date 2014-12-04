using UnityEngine;
using System.Collections;

public class TrnthCallMethod : TrnthTriggerBase {
	public GameObject target;
	public string methodName;
	public override void execute(){
		if(target.activeInHierarchy)target.SendMessage(methodName);
	}
}
