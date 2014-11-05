using UnityEngine;
using System.Collections;

public class TrnthRepeater : MonoBehaviour {
	public GameObject targetGo;
	public Component target;
	public string nameMethod;
	public float delay=1;
	public float noise=0;
	public int length;
	public void wave(){		
		waveNow-=1;
		if(targetGo)targetGo.SetActive(true);
		if(target&&target.gameObject.activeInHierarchy)target.SendMessage(nameMethod);
		if(waveNow>0){
			Invoke("wave",delay+Random.value*noise);
		}
	}
	public void start(){
		CancelInvoke();
		if(length==0)waveNow=Mathf.Infinity;
		else waveNow=length;
		Invoke("wave",delay+Random.value*noise);
		// wave();
	}
	float waveNow=0;
	void OnEnable(){
		start();
	}
	void Start(){
		// start();
	}
}
