using UnityEngine;
using TRNTH;
public class TrnthDebugShowFps : MonoBehaviour {
	public Color color;
	float delatTime;
	void update(){
		delatTime=Mathf.Floor(1.0f/Time.unscaledDeltaTime);		
		Invoke("update",0.5f*Time.timeScale);
	}
	void Start(){
		update();
		// Invoke("update",0.5f);
	}
	void OnGUI(){
		GUI.color=color;
		GUILayout.Label("fps:"+delatTime);
		GUILayout.Label("q:"+QualitySettings.GetQualityLevel());
	}
}
