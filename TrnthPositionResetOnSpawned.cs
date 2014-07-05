using UnityEngine;
using System.Collections;

public class TrnthPositionResetOnSpawned : TrnthMonoBehaviour {
	void OnSpawned(){
		tra.localPosition=Vector3.zero;
	}
}
