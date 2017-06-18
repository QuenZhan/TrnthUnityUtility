using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrnthHVSActionLevelLoad : TrnthHVSAction {
	public string levelName;
	public void gotoWithName(string levelName){
		SceneManager.LoadScene(levelName);
	}
	public void loadLevel(){
		SceneManager.LoadScene(levelName);
	}
	protected override void _execute(){
		base._execute();
		loadLevel();
	}
}
