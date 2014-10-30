using UnityEngine;
using System.Collections;

public class TrnthActivator : MonoBehaviour {
	public GameObject target;
	public float delay=1;
	public bool toggle;
	public virtual void execute(){
		target.SetActive(toggle);
	}
	void OnEnable () {
		Invoke("execute",delay);
	}
	void Awake(){
		if(!target)target=gameObject;
	}
}
