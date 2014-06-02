using UnityEngine;
using System.Collections;

public class TrnthOnSpawedToSetActive : TRNTH.PoolBase {
	public GameObject[] gobjs;
	public bool yes;
	void OnSpawned(){
		foreach(GameObject e in gobjs){
			e.SetActive(yes);
		}
	}
}
