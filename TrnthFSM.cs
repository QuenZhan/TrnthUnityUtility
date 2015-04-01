using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthFSM_ : MonoBehaviour {
	public GameObject stateNow;
	[ContextMenu("update")]
	public virtual void update(){
		transit(stateNow);
	}
	public virtual void transit(GameObject gameObject){
		stateNow=gameObject;
		foreach(Transform e in transform.Cast<Transform>().ToArray()){
			e.gameObject.SetActive(e.gameObject==stateNow);
		}
	}
	public virtual void transit(string name){
		foreach(Transform e in transform.Cast<Transform>().ToArray()){
			e.gameObject.SetActive(e.name==name);
		}
	}
	void Start(){
		transit(stateNow);
	}
}
