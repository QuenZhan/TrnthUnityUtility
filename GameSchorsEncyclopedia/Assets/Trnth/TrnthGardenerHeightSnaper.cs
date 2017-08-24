using UnityEngine;
using System.Collections;

public class TrnthGardenerHeightSnaper : MonoBehaviour {
	public Transform group;
	public Vector3 offset;
	// public LayerMask layerMask ;
	[ContextMenu("execute")]
	public void execute(){
		foreach(Transform e in group){
			var pos=e.position;
			pos.y=300;
			RaycastHit hitInfo;
			if(Physics.Raycast(pos,Vector3.up*-1,out hitInfo)){
				e.position=hitInfo.point+offset;
			}
			// e.positioin
		}
	}
}
