using UnityEngine;
using System.Collections;

public class TrnthHVSActionAudioPlay : TrnthHVSAction {
	public AudioSource audioSource;
	protected override void _execute(){
		audioSource.Play();
	}
}
