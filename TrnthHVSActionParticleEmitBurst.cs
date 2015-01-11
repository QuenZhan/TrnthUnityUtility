using UnityEngine;
using System.Collections;

public class TrnthHVSActionParticleEmitBurst : TrnthHVSAction {
	public ParticleSystem particle;
	public int number;
	public int noise;
	protected override void _execute(){
		base._execute();
		particle.Emit((int)(number+Random.value*noise));
	}
}
