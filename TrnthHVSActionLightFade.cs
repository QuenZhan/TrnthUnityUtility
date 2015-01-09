using UnityEngine;
using System.Collections;

public class TrnthHVSActionLightFade : TrnthHVSAction {
	public Light theLight;
	public float from;
	public float to;
	public float duration;
	protected override void _execute(){
		base._execute();
		if(!lightfade)lightfade=gameObject.AddComponent<TrnthLightFade>();
		lightfade.theLight=theLight;
		lightfade.from=from;
		lightfade.to=to;
		lightfade.duration=duration;
		lightfade.start();
	}
	TrnthLightFade lightfade;
}
