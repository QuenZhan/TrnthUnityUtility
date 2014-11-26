using UnityEngine;
using System.Collections;

public class TrnthActivator : MonoBehaviour {
	public GameObject target;
	public string findTarget;
	public float delay;
	public float noise=0;
	public bool toggle;
	public bool onEnable=true;
	public bool onDisable;
	public bool trigger;
	public virtual void execute(){
		// invokeExecute();
		if(target)target.SetActive(toggle);
		if(trigger){
			target.SetActive(!toggle);
			// Debug.Log("安安");
		}
	}
	void invokeExecute(){
		Invoke("execute",delay+Random.value*noise);
	}
	void OnEnable () {
		CancelInvoke();
		if(onEnable)invokeExecute();
	}
	void OnDisable(){
		if(onDisable)invokeExecute();
	}
	void Awake(){
		if(!target){
			target=GameObject.Find(findTarget);
			// target=go;
		}
		if(!target)target=gameObject;
	}
}
