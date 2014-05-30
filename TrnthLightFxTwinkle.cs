using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthLightFxTwinkle : MonoBehaviour {
	public float min;
	public float noise;
	Light _light;
	void Awake(){
		_light=light;
		min=_light.range;
	}
	void Update(){
		_light.range=min+noise*Random.value;
	}
}
