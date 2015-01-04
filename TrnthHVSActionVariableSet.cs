using UnityEngine;
using System.Collections;

public class TrnthHVSActionVariableSet : TrnthHVSAction {
	public TrnthVariable target;
	public Component component;
	protected override void _execute(){
		base._execute();
		target.write(component);
	}
}
