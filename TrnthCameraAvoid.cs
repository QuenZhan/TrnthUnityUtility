using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthCameraAvoid : TRNTH.MonoBehaviour {
	public Transform target;
	public float time=1;
	public UITweener tweener;
	public Vector3 offset;
	Alarm a=new Alarm();
	Vector3 vecOrin;
	void Start(){
		vecOrin=target.localPosition;
	}
	void OnTriggerStay(){
		a.s=time;
		tweener.Play(true);
		// enabled=true;
	}
	void Update(){
		if(!a.a){
			//target.localPosition=vecOrin+offset;
		}
		else {
			tweener.Play(false);
		}
	}
}
