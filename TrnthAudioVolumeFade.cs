using UnityEngine;
using System.Collections;

public class TrnthAudioVolumeFade : MonoBehaviour {
	public AudioSource audioSource;
	public float duration=1;
	public float from=0;
	public float to=1;
	public void play(){
		enabled=true;
		_value=from;
	}
	float _value;
	float _velocity;
	void OnEnable(){
		play();
	}
	void Update(){
		_value=Mathf.SmoothDamp(_value,to,ref _velocity,duration);
		audioSource.volume=_value;
	}
}
