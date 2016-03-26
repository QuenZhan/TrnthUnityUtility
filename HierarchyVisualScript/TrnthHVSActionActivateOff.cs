using UnityEngine;
using System.Collections;

public class TrnthHVSActionActivateOff : TrnthHVSAction {
	[SerializeField]GameObject _target;
	protected override void _execute(){
		base._execute();
		_target.SetActive(false);
	}
}
