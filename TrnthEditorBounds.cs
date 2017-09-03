using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
[ExecuteInEditMode]
public class TrnthEditorBounds : MonoBehaviour {
	public Transform parent;
	public Vector3 bound0;
	public Vector3 bound1;
	[ContextMenu("execute")]
	public void execute(){
		if(!parent)return;
		var children=new List<Transform>();
		foreach(Transform e in parent){
			children.Add(e);
		}
		// var children
		var xxyyzz=new Vector3(
				 (from node in children orderby node.transform.position.x select node.transform.position.x).First()
				,(from node in children orderby node.transform.position.y select node.transform.position.y).First()
				,(from node in children orderby node.transform.position.z select node.transform.position.z).First()
				);
		bound0=xxyyzz;
		xxyyzz=new Vector3(
				 (from node in children orderby node.transform.position.x select node.transform.position.x).Last()
				,(from node in children orderby node.transform.position.y select node.transform.position.y).Last()
				,(from node in children orderby node.transform.position.z select node.transform.position.z).Last()
				);
		bound1=xxyyzz;
	}
	void Update(){
		execute();
	}
	void OnDrawGizmos(){
		Gizmos.DrawLine(new Vector3(bound0.x,bound0.y,bound0.z)
			,new Vector3(bound0.x,bound0.y,bound1.z));
		Gizmos.DrawLine(new Vector3(bound0.x,bound0.y,bound0.z)
			,new Vector3(bound1.x,bound0.y,bound0.z));
		Gizmos.DrawLine(new Vector3(bound0.x,bound0.y,bound0.z)
			,new Vector3(bound0.x,bound1.y,bound0.z));
		Gizmos.DrawLine(new Vector3(bound1.x,bound1.y,bound1.z)
			,new Vector3(bound0.x,bound1.y,bound1.z));
		Gizmos.DrawLine(new Vector3(bound1.x,bound1.y,bound1.z)
			,new Vector3(bound1.x,bound1.y,bound0.z));
		Gizmos.DrawLine(new Vector3(bound1.x,bound1.y,bound1.z)
			,new Vector3(bound1.x,bound0.y,bound1.z));

	}
}
