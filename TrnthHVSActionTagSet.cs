using UnityEngine;
using System.Collections;

public class TrnthHVSActionTagSet : TrnthHVSAction {
	public GameObject target;
	public string tagName;
	protected override void _execute(){
		base._execute();
		target.tag=tagName;
	}
}
