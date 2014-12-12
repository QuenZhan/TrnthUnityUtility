using UnityEngine;
using System.Collections;

public class TrnthAnimatorProxySubscribe : MonoBehaviour {
	public TrnthAnimatorProxy proxy;
	public GameObject targetToggle;
	public void callback(){
		targetToggle.SetActive(true);
		targetToggle.SetActive(false);
	}
	void OnEnable(){
		proxy.callback-=callback;
		proxy.callback+=callback;
	}

}
