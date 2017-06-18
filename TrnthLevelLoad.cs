using UnityEngine;
using System.Collections;

public class TrnthLevelLoad : MonoBehaviour {
	public string levelName;
	public void gotoWithName(string levelName){
//		Application.LoadLevel(levelName);
	}
	public void loadLevel(){
//		Application.LoadLevel(levelName);
	}
	void OnEnable(){
		loadLevel();
	}
	void OnClick(){
		loadLevel();	
	}
}
