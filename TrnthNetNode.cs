using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
[ExecuteInEditMode]
public class TrnthNetNode : MonoBehaviour {
	static List<TrnthNetNode> nodes=new List<TrnthNetNode>();
	public List<TrnthNetNode> inRadius=new List<TrnthNetNode>();
	public float radius=10;
	public int connected=2;
	[ContextMenu("refresh")]
	public void refresh(){
		nodes.Clear();
		// data source 
		foreach(Transform e in transform.parent){
			var node=e.GetComponent<TrnthNetNode>();
			if(!node)continue;
			nodes.Add(node);
		}
		foreach(var e in nodes){
			e.inRadius.Clear();
		}
		// query
		var q=from n1 in nodes
				from n2 in nodes 
				let distance=(n1.transform.position-n2.transform.position).magnitude
				where n1!=n2 && distance<radius
				orderby distance
				select new {n1=n1,n2=n2};
		// query execution
		foreach(var e in q){
			e.n1.inRadius.Add(e.n2);
		}
	}
	void Update(){
		refresh();
	}
	void OnDrawGizmos(){
		// if(inRadius.Count<1)return;
		foreach(var e in inRadius.Take(connected)){
			Gizmos.DrawLine(transform.position,e.transform.position);
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(transform.position,radius);
	}
}
