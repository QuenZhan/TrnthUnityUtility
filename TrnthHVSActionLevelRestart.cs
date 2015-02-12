using UnityEngine;
using System.Collections;

public class TrnthHVSActionLevelRestart : MonoBehaviour {
	protected override void _execute(){
		// Application.
		Application.LoadLevel(Application.loadedLevel);
	}
}
