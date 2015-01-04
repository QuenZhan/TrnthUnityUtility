using UnityEngine;
using System.Collections;

public class TrnthFSMRenderer : TrnthFSM  {
	public Renderer rdr{get;private set;}
	public override bool transit(Component state){
		rdr=state as Renderer;
		if(!rdr)return false;
		return base.transit(rdr);
	}
}