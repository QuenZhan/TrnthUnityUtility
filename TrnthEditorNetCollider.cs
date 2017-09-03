using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrnthEditorNetCollider : TrnthEditor {
	public TrnthEditorNetNode node;
	public float radius=5;
	// Line[] lines=new Line[0];
	[ContextMenu("refresh")]
	public void refresh(){
		clear();
		var q=from n in node.nodes 
			from nc in n.connected.Cast<TrnthEditorNetNode>()
			select new Line{node0=n,node1=nc};
		
		var lines=q.Distinct(new IEqualityComparerLine()).ToArray();
		foreach(var e in lines){
			var go=new GameObject("node collider");
			var capsule=go.AddComponent<CapsuleCollider>();
			go.transform.position=e.node0.transform.position;
			go.transform.LookAt(e.node1.transform);
			var distance=(e.node0.transform.position-e.node1.transform.position).magnitude;
			capsule.height=distance+radius*2;
			capsule.radius=radius;
			capsule.direction=2;
			capsule.center=Vector3.forward*distance*0.5f;
			go.transform.parent=transform;
			go.layer=gameObject.layer;
		}
	}

	// [System.Serializable]
	class Line{
		public TrnthEditorNetNode node0;
		public TrnthEditorNetNode node1;
	}
	class IEqualityComparerLine : IEqualityComparer<Line> {
	    public bool Equals(Line x, Line y) {
	        return (x.node0==y.node0&&x.node1==y.node1)
	        	||(x.node0==y.node1&&x.node0==y.node1);
	    }
	    public int GetHashCode(Line obj) {
	        return obj.node0.GetHashCode() ^
	            obj.node1.GetHashCode();
	    }
	}
}
