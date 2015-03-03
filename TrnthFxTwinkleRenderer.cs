using UnityEngine;
using System.Collections;

public class TrnthFxTwinkleRenderer : TrnthFx {
	public Renderer rdr;
	public float duration=2;
	public float delayBetween=0.06f;
	public override void start(){
		base.start();
		Invoke("end",duration);
		Invoke("toggle",delayBetween);
		// toggle();
	}
	void toggle(){
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
