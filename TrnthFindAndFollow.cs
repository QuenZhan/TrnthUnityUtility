using UnityEngine;
using System.Collections;

public class TrnthFindAndFollow : MonoBehaviour {
	public Transform target;
	public string theName;
	public void find(){
		target=GameObject.Find(""+theName).transform;
	}
	void Start(){
		find();
	}
	void Update(){		
		transform.position=target.position;
		transform.eulerAngles=transform.eulerAngles;
	}
}
