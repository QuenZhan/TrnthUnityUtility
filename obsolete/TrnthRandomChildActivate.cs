using UnityEngine;
using System.Collections;

public class TrnthRandomChildActivate : MonoBehaviour {
	public Transform target;
	void Awake(){
		if(!target)target=transform;
	}
	void OnEnable(){
		// foreach(Transform e in target){
		// 	e.gameObject.SetActive(false);
		// }
		TrnthFSM.transit(TRNTH.U.chooseChild(target));
		// TRNTH.U.choose(target).gameObject.SetActive(true);
	}
}
