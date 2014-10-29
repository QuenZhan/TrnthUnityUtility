using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthColliderProjector : TrnthMonoBehaviour {
	public bool isHit;
	public float distance=10;
	public float radius=0;
	public string sendMsgToSelf;
	public string sendMsgToHit;
	public string nameContain="";
	public GameObject target;
	public GameObject[] onHit;
	public LayerMask layermask;
	void Update (){
		RaycastHit hit;
		if(radius==0){
			isHit=Physics.Raycast(pos,transform.forward,out hit,distance,layermask.value);
		}else{
			isHit=Physics.SphereCast(pos,radius,transform.forward,out hit,distance,layermask.value);
		}
		// isHit=isHit;
		// isHit=isHit&&hit.collider.name.Contains(nameContain);
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
			Debug.Log(hit.collider.name);
			
		}
		if(onHit.Length>0){
			foreach(var e in onHit){e.SetActive(isHit);}
			
		}
	}
}
