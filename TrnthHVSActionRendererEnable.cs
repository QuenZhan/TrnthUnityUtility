using UnityEngine;
using System.Collections;

public class TrnthHVSActionRendererEnable : TrnthHVSAction {
	public TrnthHVSActionActivate.Mode mode;
	public Renderer rdr;
	public TrnthFSMRenderer proxy;
	protected override void _execute(){
		if(proxy)rdr=proxy.rdr;
		switch(mode){
		case TrnthHVSActionActivate.Mode.on			:rdr.enabled=true;break;
		case TrnthHVSActionActivate.Mode.off		:rdr.enabled=false;break;
		case TrnthHVSActionActivate.Mode.toggle		:rdr.enabled=!rdr.enabled;break;
		case TrnthHVSActionActivate.Mode.trigger:
			rdr.enabled=true;
			rdr.enabled=false;
			break;
		}
	}
}
