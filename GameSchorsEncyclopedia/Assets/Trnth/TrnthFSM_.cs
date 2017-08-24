using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthFSM_ : MonoBehaviour {
	// static public void transit(GameObject gameObject){
	// 	var fsmManager=state.transform.parent.GetComponent<TrnthFSMManager>();
	// 	fsmManager.stateNow=state;
	// 	fsmManager.update();
	// }
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
			if(e.name==name)stateNow=e.gameObject;
			e.gameObject.SetActive(e.name==name);			
		}
	}
	void Start(){
		transit(stateNow);
	}
}
