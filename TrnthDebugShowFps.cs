using UnityEngine;
using TRNTH;
public class TrnthDebugShowFps : MonoBehaviour {
	public Color color;
	void OnGUI(){
		GUI.color=color;
		GUILayout.Label("fps:"+Mathf.Floor(1.0f/Time.smoothDeltaTime));
		GUILayout.Label("q:"+QualitySettings.GetQualityLevel());
	}
}
