using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
[ExecuteInEditMode]
public class TrnthEditorNetGroup : TrnthEditorNet {
	public TrnthEditorNetNode[] nodes;
	[ContextMenu("refresh")]
	public void refresh(){
		var list=new List<TrnthEditorNetNode>();
		foreach(Transform e in transform){
			var node=e.GetComponent<TrnthEditorNetNode>();
			if(!node)continue;
			list.Add(node);
		}
		nodes=list.ToArray();
	}
}
