using UnityEngine;
using System.Collections;

public class TrnthPositionResetOnSpawned : TrnthMonoBehaviour {
	void OnDespawned(){
		Debug.Log("dfsdf");
		tra.localPosition=Vector3.zero;
	}
}
