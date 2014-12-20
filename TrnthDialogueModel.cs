using UnityEngine;
using System.Collections;

public class TrnthDialogueModel : MonoBehaviour {
	public string text;
	public AudioSource voice;
	public float duration{get{
		if(voice&&voice.clip)return voice.clip.length;
		return 2;
	}}
}
