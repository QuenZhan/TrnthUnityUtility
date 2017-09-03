using UnityEngine;
using System.Collections;
public class TrnthHVSActionRendererEnable : TrnthHVSAction {
	public bool on;
	public Renderer rdr;
	protected override void _execute(){
		rdr.enabled=on;
	}
}
