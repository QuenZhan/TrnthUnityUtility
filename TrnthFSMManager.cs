using UnityEngine;
using System.Collections;

public class TrnthFSMManager : MonoBehaviour {
	public GameObject stateNow;
	public void update(){
		foreach(Transform e in transform){
			// if(e.gameObject.activeInHierarchy)e.gameObject.SetActive(false);
			e.gameObject.SetActive(e.gameObject==stateNow);
		}
		// if(!stateNow.activeInHierarchy)stateNow.SetActive(true);
	}
}
