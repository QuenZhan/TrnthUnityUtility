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
//	void Start () {
//		foreach(Transform e in Root){
//			var target=e.GetComponent<TheTarget>();
//			targets.Add(target);
//			colliderToTarget.Add(target.Collider,target);
//		}
//	}
	Collider2D[] colliders=new Collider2D[1000];
	public LayerMask layerMask;
	// Update is called once per frame
	class HeapThing{
//		public HeapThing Boo;
		public int Number;
		public int Number2;
		public int Number3;
		public string Str;
	}
	const int Size=10000;
	HeapThing[] heaps=new HeapThing[Size];
	string[] strs=new string[Size];
	int[] numbers=new int[Size];
	int[] numbers2=new int[Size];
	int[] numbers3=new int[Size];
	const string Strrrr="Strrrr";
	void Start(){
		for(var i=0;i<Size;i++){
			heaps[i]=new HeapThing(){Number=i,Str=string.Empty};
			strs[i]=string.Empty;
			numbers[i]=i;
		}
	}
	void Update () {
//		var count1=PhysicsOverLap();
//		var count2=Iterator();
//		Debug.LogFormat("PhysicsOverLap:{0} , Iterator:{1}",count1,count2);
		HeapObject();
		ArraySeperate();
	}
	void HeapObject(){
		for(var i=0;i<Size;i++){
			var heap=heaps[i];
			heap.Number/=3;
			heap.Number2/=3;
			heap.Number3/=3;
//			heap.Str+="";
		}
	}
	void ArraySeperate(){
		for(var i=0;i<Size;i++){
			numbers[i]/=3;
			numbers2[i]/=3;
			numbers3[i]/=3;
//			strs[i]+="";
		}
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
