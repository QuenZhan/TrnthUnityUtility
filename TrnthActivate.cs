using UnityEngine;
using System.Collections;

public class TrnthActivate : MonoBehaviour {
	public GameObject target;
	public float delay=1;
	public bool toggle;
	public void execute(){
		target.SetActive(toggle);
	}
	void OnEnable () {
		Invoke("execute",delay);
	}
	void Awake(){
		if(!target)target=gameObject;
	}
}
