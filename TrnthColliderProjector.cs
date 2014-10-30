using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthColliderProjector : TrnthMonoBehaviour {
	public bool isHit;
	public float distance=10;
	public float radius=0;	
	public string sendMsgToSelf;
	public string sendMsgToHit;
	public GameObject target;
	public GameObject[] onHit;
	public GameObject[] onHiting;
	public LayerMask layermask;
	public void update(){
		RaycastHit hit;
		var _isHit=isHit;
		if(radius==0){
			isHit=Physics.Raycast(pos,transform.forward,out hit,distance,layermask.value);
		}else{
			isHit=Physics.SphereCast(pos,radius,transform.forward,out hit,distance,layermask.value);
		}
		if(isHit){
			target.transform.position=hit.point;			
			if(sendMsgToSelf!=""){
				// Debug.Log()
				SendMessage(sendMsgToSelf);
			}
			if(sendMsgToHit!=""){
				// Debug.Log()
				hit.collider.SendMessage(sendMsgToHit);
			}
			if(_isHit!=isHit){
				foreach(var e in onHit)e.SetActive(true);
			}
		}
		foreach(var e in onHiting){if(e)e.SetActive(isHit);}
	}

	void Update (){
		update();
	}
}
