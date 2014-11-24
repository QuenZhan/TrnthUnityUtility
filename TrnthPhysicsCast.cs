using UnityEngine;
using System.Collections;
using System.Linq;
[ExecuteInEditMode]
public class TrnthPhysicsCast : TrnthMonoBehaviour {
	// [Header("PhysicsCast")]
	public bool log;
	public float distance=10;
	public float radius=0;
	public GameObject target;
	public LayerMask layermask;
	public Collider[] colliders;
	[Header("Filter")]
	public bool filter;
	public string[] include;
	public string[] exclude;
	[Header("Event")]
	public string sendMsgToSelf;
	public string sendMsgToHit;
	public GameObject[] onHit;
	public GameObject[] onNotHit;
	public GameObject[] onHiting;
	public void update(){
		// var _isHit=isHit;
		var point=Vector3.zero;
		// getcolliders
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
		// filter colliders
		if(filter){
			var q=from collider in colliders
				from inc in include
				// from exc in exclude
				where (collider.name.Contains(inc))
				// where (include.Length < 1||collider.name.Contains(inc))
					// &&(exclude.Length < 1||!collider.name.Contains(exc))
				select collider;
			// q=from collider in q
			// 	from filter in exclude
			// 	where (!collider.name.Contains(filter))
			// 	select collider;
			colliders=q.ToArray();			
		}
		if(log)Debug.Log(colliders);
		// send msg to colliders hit
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
				foreach(var e in onHit)e.SetActive(true);
			// if(_isHit!=isHit){
			// }
		}else{
			foreach(var e in onNotHit)e.SetActive(true);
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
