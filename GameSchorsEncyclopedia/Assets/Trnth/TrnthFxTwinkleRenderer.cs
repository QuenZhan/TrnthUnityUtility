using UnityEngine;
using System.Collections;

public class TrnthFxTwinkleRenderer : TrnthFx {
	public Renderer rdr;
	public float duration=2;
	public float delayBetween=0.06f;
	[ContextMenu("start")]
	public override void start(){
		base.start();
		CancelInvoke();
		Invoke("end",duration);
		toggle();
	}
	void toggle(){
		if(!rdr)return;
		rdr.enabled=!rdr.enabled;
		Invoke("toggle",delayBetween);
	}
	protected override void end(){
		CancelInvoke();
		rdr.enabled=true;
		base.end();
	}
}
