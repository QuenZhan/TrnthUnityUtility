using UnityEngine;
using System.Collections;

public class TrnthAnimatorProxySubscribe : MonoBehaviour {
	public bool log;
	public TrnthAnimatorProxy proxy;
	public GameObject targetToggle;
	public void callback(){
		if(log)Debug.Log("安安");
		targetToggle.SetActive(true);
		targetToggle.SetActive(false);
	}
	void OnEnable(){
		proxy.callback-=callback;
		proxy.callback+=callback;
	}

}
