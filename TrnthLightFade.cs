using UnityEngine;
using System.Collections;

public class TrnthLightFade : MonoBehaviour {
	public Light theLight;
	// public float delay;
	public float from;
	public float to;
	public float duration;
	float yVelocity;
	public void start(){
		enabled=true;
	}
	void OnEnable(){
		if(!theLight)return;
		theLight.intensity=from;
	}
	void Update(){
		theLight.intensity=Mathf.SmoothDamp(theLight.intensity,to, ref yVelocity, duration);
	}
}
