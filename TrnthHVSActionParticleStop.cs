using UnityEngine;
using System.Collections;

public class TrnthHVSActionParticleStop : TrnthHVSAction {
	public ParticleSystem particle;
	protected override void _execute(){
		particle.Stop();
	}
}
