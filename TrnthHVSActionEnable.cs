using UnityEngine;
using System.Collections;

public class TrnthHVSActionEnable : TrnthHVSAction {
	public bool on;
	public Behaviour behaviour;
	protected override void _execute(){
		behaviour.enabled=on;
	}
}
