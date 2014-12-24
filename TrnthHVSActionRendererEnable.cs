using UnityEngine;
using System.Collections;

public class TrnthHVSActionRendererEnable : TrnthHVSAction {
	public TrnthHVSActionActivate.Mode mode;
	public Renderer renderer;
	public TrnthFSMRenderer proxy;
	protected override void _execute(){
		if(proxy)renderer=proxy.renderer;
		switch(mode){
		case TrnthHVSActionActivate.Mode.on		:renderer.enabled=true;break;
		case TrnthHVSActionActivate.Mode.off	:renderer.enabled=false;break;
		case TrnthHVSActionActivate.Mode.toggle	:renderer.enabled=!renderer.enabled;break;
		case TrnthHVSActionActivate.Mode.trigger:
			renderer.enabled=true;
			renderer.enabled=false;
			break;
		}
	}
}
