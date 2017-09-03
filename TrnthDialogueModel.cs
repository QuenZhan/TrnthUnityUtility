using UnityEngine;
using System.Collections;
[System.Serializable]
public struct TrnthDialogueModel {
	public string text;
	public AudioSource voice;
	public float duration{get{
		if(voice&&voice.clip)return voice.clip.length+2;
		return 2;
	}}
}
