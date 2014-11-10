using UnityEngine;
using System.Collections;

public class TrnthLightFade : MonoBehaviour {
	public Light theLight;
	public float from;
	public float to;
	public float duration;
	float yVelocity;
	void OnEnable(){
		theLight.intensity=from;
	}
	void Update(){
		theLight.intensity=Mathf.SmoothDamp(theLight.intensity,to, ref yVelocity, duration);
	}
}
