using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthColliderProjector : TrnthMonoBehaviour {
	public bool isHit;
	public float distance=10;
	public string sendMsg;
	public GameObject target;
	public GameObject[] onHit;
	public LayerMask layermask;
	void Update (){
		RaycastHit hit;
		isHit=Physics.Raycast(pos,transform.forward,out hit,distance,layermask.value);
		if(isHit){
			target.transform.position=hit.point;
			if(sendMsg!="")SendMessage(sendMsg);
		}
		if(onHit.Length>0){
			foreach(var e in onHit){e.SetActive(isHit);}
			
		}
	}
}
