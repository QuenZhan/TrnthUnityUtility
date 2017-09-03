using UnityEngine;
using System.Collections;

public class TrnthHVSActionActivateOn : TrnthHVSAction {
	[SerializeField]GameObject _target;
	protected override void _execute(){
		base._execute();
		_target.SetActive(true);
	}
}
