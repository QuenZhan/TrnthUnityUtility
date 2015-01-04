using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthHVSActionPhysicsCast : TrnthHVSAction {
	public bool isHit{get;private set;}
	public float distance=10;
	public float radius=0;
	// public string[] include;
	public LayerMask layermask;
	public Collider[] colliders{get;private set;}
	// bool filter;
	public TrnthHVSCondition onHit;
	// public TrnthHVSCondition onHitDown;
	public TrnthHVSCondition onHitNot;
	public void update(){
		var pos=transform.position;
		// getcolliders
		colliders=new Collider[0];
		if(distance==0){
			colliders=Physics.OverlapSphere(pos,radius,layermask.value);
			isHit=colliders.Length>0;
		}else{
			// RaycastHit hit;
			if(radius==0){
				isHit=Physics.Raycast(pos,transform.forward,out hit,distance,layermask.value);
			}else{
				isHit=Physics.SphereCast(pos,radius,transform.forward,out hit,distance,layermask.value);
			}		
			if(isHit){
				colliders=new Collider[]{hit.collider};
			}
		}
		// filter colliders
		// if(filter){
		// 	var q=from collider in colliders
		// 		from inc in include
		// 		where (collider.name.Contains(inc))
		// 		select collider;
		// 	colliders=q.ToArray();
		// 	isHit=colliders.Length>0;
		// }
		if(isHit){
			if(onHit)onHit.send();
		}else{
			if(onHitNot)onHitNot.send();
		}
	}
	protected override void _execute(){
		base._execute();
		update();
	}
	protected RaycastHit hit;
	void OnDrawGizmosSelected() {
		var pos=transform.position;
		var pos1=pos;
		var pos2=pos+transform.forward*distance;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos1,radius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pos2,radius);
        Gizmos.DrawLine(pos1,pos2);
    }
}
