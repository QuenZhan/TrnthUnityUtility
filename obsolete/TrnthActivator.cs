using UnityEngine;
using System.Collections;

public class TrnthActivator : TrnthTriggerBase {
	public GameObject target;
	public string findTarget;
	public bool toggle;
	public bool trigger;
	public override void execute(){
		base.execute();
		if(target)target.SetActive(toggle);
		if(trigger){
			target.SetActive(!toggle);
		}
	}
	void Awake(){
		if(!target){
			target=GameObject.Find(findTarget);
			// target=go;
		}
		if(!target&&findTarget=="")target=gameObject;
	}
}
