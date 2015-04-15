using UnityEngine;
using System.Collections;
[System.Serializable]
public class TrnthDialogueModel {
	public string text;
	public AudioSource voice;
	public float duration{get{
		if(voice&&voice.clip)return voice.clip.length;
		return 2;
	}}
}
