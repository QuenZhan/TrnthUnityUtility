using UnityEngine;
using System.Collections;

public class TrnthUiButtonUrl : MonoBehaviour {
	public string url;
	public void OnClick(){
		Application.OpenURL(url);
	}
}
