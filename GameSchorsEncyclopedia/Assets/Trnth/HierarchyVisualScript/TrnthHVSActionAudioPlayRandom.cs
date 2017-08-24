using UnityEngine;
using System.Collections;
using System.Linq;
using TRNTH;
public class TrnthHVSActionAudioPlayRandom : TrnthHVSAction {
	public Transform target;
	protected override void _execute(){
		var audio=target.Cast<Transform>().CastComponent<AudioSource>().RandomChooseNonAlloc();
		audio.Play();
	}
}
