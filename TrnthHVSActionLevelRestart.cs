using UnityEngine;
using System.Collections;

public class TrnthHVSActionLevelRestart : TrnthHVSAction {
	protected override void _execute(){
		// Application.
		Application.LoadLevel(Application.loadedLevel);
	}
}
