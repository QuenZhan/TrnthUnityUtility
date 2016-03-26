using UnityEngine;
using System.Collections;

public class TrnthHVSActionParticlePlay : TrnthHVSAction {
	public ParticleSystem particle;
	protected override void _execute(){
		particle.Play();
	}
}
