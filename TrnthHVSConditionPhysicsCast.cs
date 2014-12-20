using UnityEngine;
using System.Collections;
using System.Linq;
[ExecuteInEditMode]
public class TrnthHVSConditionPhysicsCast : TrnthHVSCondition {
	// [Header("PhysicsCast")]
	public bool isHit=false;
	public float distance=10;
	public float radius=0;
	public GameObject target;
	public LayerMask layermask;
	public Collider[] colliders;
	public bool filter;
	public string[] include;
	public void update(){
		// var _isHit=isHit;
		var point=Vector3.zero;
		pos=transform.position;
		// getcolliders
		colliders=new Collider[0];
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
			if(isHit){
				point=hit.point;
				colliders=new Collider[]{hit.collider};				
			}
		}
		// filter colliders
		if(filter){
			var q=from collider in colliders
				from inc in include
				where (collider.name.Contains(inc))
				select collider;
			colliders=q.ToArray();			
		}
		if(isHit){
			execute();
		}
	}
	Vector3 pos;
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
