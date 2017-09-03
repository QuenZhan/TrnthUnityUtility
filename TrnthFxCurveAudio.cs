using UnityEngine;
using System.Collections;

public class TrnthFxCurveAudio : TrnthFxCurve {
	public AudioSource audioSource;
	protected override void update(){
		audioSource.volume=curveValue;
	}
}
