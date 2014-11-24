using UnityEngine;
using System.Collections;

public class TrnthActivator : MonoBehaviour {
	public GameObject target;
	public string findTarget;
	public float delay=1;
	public float noise=0;
	public bool toggle;
	public bool onEnable=true;
	public bool onDisable;
	public virtual void execute(){
		// invokeExecute();
		if(target)target.SetActive(toggle);
	}
	void invokeExecute(){
		Invoke("execute",delay+Random.value*noise);
	}
	void OnEnable () {
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
