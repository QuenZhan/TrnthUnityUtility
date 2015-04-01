using UnityEngine;
using System.Collections;

public class TrnthFxTwinkleRenderer : TrnthFx {
	public Renderer rdr;
	public float duration=2;
	public float delayBetween=0.06f;
	[ContextMenu("start")]
	public override void start(){
		base.start();
		// Debug.Log("安安");
		CancelInvoke();
		Invoke("end",duration);
		// Invoke("toggle",delayBetween);
		toggle();
	}
	void toggle(){
		if(!rdr)return;
		rdr.enabled=!rdr.enabled;
		Invoke("toggle",delayBetween);
	}
	// protected override void update(){
	// 	base.update();
	// }
	protected override void end(){
		rdr.enabled=true;
		base.end();
	}
}
