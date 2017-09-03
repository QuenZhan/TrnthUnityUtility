using UnityEngine;
using System.Collections;

public class TrnthRandomScale : MonoBehaviour {
	public Transform target;
	public Vector3 orin=Vector3.one;
	public Vector3 noise=Vector3.zero;
	public void execute(){
		target.localScale=orin+Random.value*noise;
	}
	void OnSpawned(){
		execute();
	}
	// Use this for initialization
	void Start () {
		execute();
	}
	void Awake(){
		if(!target)target=transform;
	}
}
