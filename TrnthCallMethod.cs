using UnityEngine;
using System.Collections;

public class TrnthCallMethod : MonoBehaviour {
	public GameObject target;
	public string methodName;
	public float delay;
	public void execute(){
		target.SendMessage(methodName);
	}
	void OnEnable(){
		Invoke("execute",delay);
	}
}
