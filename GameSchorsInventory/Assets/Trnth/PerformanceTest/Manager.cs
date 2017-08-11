using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
	public Transform Root;
	public Collider colliderToOverlap;
	public ContactFilter2D filter;
	List<TheTarget> targets=new List<TheTarget>();
	// Use this for initialization
	Dictionary<Collider2D,TheTarget> colliderToTarget=new Dictionary<Collider2D, TheTarget>();
	void Start () {
		foreach(Transform e in Root){
			var target=e.GetComponent<TheTarget>();
			targets.Add(target);
			colliderToTarget.Add(target.Collider,target);
		}
	}
	Collider2D[] colliders=new Collider2D[1000];
	public LayerMask layerMask;
	// Update is called once per frame
	void Update () {
		var count1=PhysicsOverLap();
		var count2=Iterator();
		Debug.LogFormat("PhysicsOverLap:{0} , Iterator:{1}",count1,count2);
	}
	int Iterator(){
		var size=targets.Count;
//		var bound=new Bounds(){center=new Vector3(0.5f,0.5f,0),size=new Vector3(1,1,0)};
		var vec=new Vector2(0.5f,0.5f);
		var count=0;
		for(var i=0;i<size;i++){
			var ata=targets[i].Collider.OverlapPoint(vec);
			if(!ata)continue;
//			var vaue=
			targets[i].Hurt();
			count++;

		}
		return count;
	}
	int PhysicsOverLap(){
		var vec=new Vector2(0.5f,0.5f);
//		var con
		var count=Physics2D.OverlapPointNonAlloc(vec,colliders,layerMask);
		for(var i=0;i<count;i++){
			colliderToTarget[colliders[i]].Hurt();
		}
		return count;
	}
			
}
