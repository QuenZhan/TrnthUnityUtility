using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class TrnthHVSActionPhysicsCast : TrnthHVSAction {
	public bool isHit{get;private set;}
	public float distance=10;
	public float radius=0;
	[Tooltip("take nearest colliders in numbers , zero means take all")]
	public int take;
	public LayerMask layermask;
	public Collider[] colliders;
	public TrnthHVSCondition onHit;
	public TrnthHVSCondition onHitNot;
	public event Action<TrnthHVSActionPhysicsCast,Collider[]> eCast=delegate{};
	public void update(){
		var pos=transform.position;
		colliders=new Collider[0];
		if(distance==0){
			colliders=Physics.OverlapSphere(pos,radius,layermask.value);
			isHit=colliders.Length>0;
		}else{
			// RaycastHit hit;
			if(radius==0){
				isHit=Physics.Raycast(pos,transform.forward,out hit,distance,layermask.value);
				colliders=new Collider[]{hit.collider};
			}else{
				var hits=Physics.SphereCastAll(pos,radius,transform.forward,distance,layermask.value);
				var q=from e in hits
					orderby (e.transform.position-transform.position).magnitude
					select e.collider;
				isHit=q.Count()>0;
				colliders=q.ToArray();
			}
		}
		if(take!=0){
			var q=from e in colliders
				where e!=null
				orderby (e.transform.position-transform.position).magnitude
				select e;
			colliders=q.Take(take).ToArray();
		}
		eCast(this,colliders);
		if(isHit){
			if(onHit)onHit.send();
		}else{
			if(onHitNot)onHitNot.send();
		}
	}
	protected override void _execute(){
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