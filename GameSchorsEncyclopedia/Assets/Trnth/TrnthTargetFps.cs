using UnityEngine;
using System.Collections;

public class TrnthTargetFps : MonoBehaviour {
	public int value=60;
	void Awake(){
		Application.targetFrameRate = value;
	}
}
