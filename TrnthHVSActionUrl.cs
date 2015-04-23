using UnityEngine;
using System.Collections;

public class TrnthHVSActionUrl : TrnthHVSAction {
	public string url;
	protected override void _execute(){
		base._execute();
		Application.OpenURL(url);
	}
}
