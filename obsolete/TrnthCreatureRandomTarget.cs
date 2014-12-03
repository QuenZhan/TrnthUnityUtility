using UnityEngine;
using System.Collections;

public class TrnthCccRandomTarget : TrnthMonoBehaviour {
	public TrnthCreature ccc;
	public float radius;
	public float time;
	public float timeNoise;
	public void execute(){
		pos=ccc.transform.position+Random.onUnitSphere*radius;
		ccc.targetPersitant=gameObject;
		Invoke("execute",time+timeNoise);
	}
	void Start(){
		//tra.parent=null;
	}
	void OnDisable(){
		CancelInvoke();
	}
	void OnEnable(){
		execute();
	}
}
