using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthPhysicsCast : TrnthMonoBehaviour {
	public float distance=10;
	public float radius=0;
	public string sendMsgToSelf;
	public string sendMsgToHit;
	public GameObject target;
	public GameObject[] onHit;
	public GameObject[] onHiting;
	public LayerMask layermask;
	public Collider[] colliders;
	public void update(){
		var _isHit=isHit;
		var point=Vector3.zero;
		// Collider[] colliders=new Collider[0];
		if(distance==0){
			colliders=Physics.OverlapSphere(pos,radius,layermask.value);
			isHit=colliders.Length>0;
		}else{
			RaycastHit hit;
			if(radius==0){
				isHit=Physics.Raycast(pos,transform.forward,out hit,distance,layermask.value);
			}else{
				isHit=Physics.SphereCast(pos,radius,transform.forward,out hit,distance,layermask.value);
			}		
			point=hit.point;
			colliders=new Collider[]{hit.collider};
		}
		if(isHit){
			if(target)target.transform.position=point;
			if(sendMsgToSelf!=""){
				// Debug.Log()
				SendMessage(sendMsgToSelf);
			}
			if(sendMsgToHit!=""){
				foreach(var e in colliders){
					e.SendMessage(sendMsgToHit);
				}
			}
			if(_isHit!=isHit){
				foreach(var e in onHit)e.SetActive(true);
			}
		}
		foreach(var e in onHiting){if(e)e.SetActive(isHit);}
	}
	bool isHit=false;
	void Update (){
		update();
	}
	void OnEnable(){
		update();
	}
	void OnDrawGizmosSelected() {
		var pos1=pos;
		var pos2=pos+transform.forward*distance;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos1,radius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pos2,radius);
        Gizmos.DrawLine(pos1,pos2);
    }
}
