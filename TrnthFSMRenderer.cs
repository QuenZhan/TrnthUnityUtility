using UnityEngine;
using System.Collections;

public class TrnthFSMRenderer : TrnthFSM  {
	public Renderer renderer;
	public override bool transit(Component state){
		renderer=state as Renderer;
		if(!renderer)return false;
		return base.transit(renderer);
	}
}
