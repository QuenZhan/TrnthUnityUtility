using UnityEngine;
using System.Collections;

public class TrnthHVSActionLevelLoad : TrnthHVSAction {
	public string levelName;
	public void gotoWithName(string levelName){
		Application.LoadLevel(levelName);
	}
	public void loadLevel(){
		Application.LoadLevel(levelName);
	}
	protected override void _execute(){
		base._execute();
		loadLevel();
	}
}
