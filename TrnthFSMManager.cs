using UnityEngine;
using System.Collections;

public class TrnthFSMManager : MonoBehaviour {
	public GameObject stateNow;
	[ContextMenu("update")]
	public virtual void update(){
		transit(stateNow);
	}
	public virtual void transit(GameObject gameObject){
		stateNow=gameObject;
		foreach(Transform e in transform){
			e.gameObject.SetActive(e.gameObject==stateNow);
		}
	}
	void Awake(){
		transit(stateNow);
	}
}
