using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
[ExecuteInEditMode]
public class TrnthEditorNetNode : MonoBehaviour {
	static List<TrnthEditorNetNode> _nodes=new List<TrnthEditorNetNode>();
	public float radius=10;
	public int connectMAx=2;
	public Color color=Color.white;
	public TrnthEditorNetNode[] connected{get{
		return inRadius.Take(connectMAx).ToArray();
	}}
	public TrnthEditorNetNode[] nodes{
		get{return _nodes.ToArray();}
	}
	[HideInInspector]
	public bool isEnd;
	[ContextMenu("refresh")]
	public void refresh(){
		var nodeGroup=GetComponentInParent<TrnthEditorNetGroup>();
		nodeGroup.refresh();
		_nodes=nodeGroup.nodes.ToList();
		// _nodes.Clear();
		// Start();
	}
	public void update(){
		if(_nodes.Count<1)refresh();
		inRadius.Clear();
		var q=
				from n2 in _nodes 
				let distance=(transform.position-n2.transform.position).magnitude
				where this!=n2 && distance<radius
				orderby distance
				select n2;
		// query execution
		foreach(var e in q){
			this.inRadius.Add(e);
		}
		isEnd=inRadius.Count<=1;
	}
	List<TrnthEditorNetNode> inRadius=new List<TrnthEditorNetNode>();
	void Start(){
		refresh();
	}
	void OnDestroy(){
		refresh();
	}
	void Update(){
		update();
	}
	void OnDrawGizmos(){
		Gizmos.color=color;
		Gizmos.DrawWireCube(transform.position,Vector3.one);
		Gizmos.DrawWireCube(transform.position,Vector3.one);
		if(isEnd)Gizmos.DrawWireCube(transform.position,Vector3.one*1.5f);
		foreach(var e in connected){
			Gizmos.DrawLine(transform.position,e.transform.position);
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.color=color;
		Gizmos.DrawWireSphere(transform.position,radius);
	}
}
