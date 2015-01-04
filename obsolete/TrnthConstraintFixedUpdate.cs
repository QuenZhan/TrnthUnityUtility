using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthConstraintFixedUpdate : MonoBehaviour {
	public Transform target;
	public float rate=0.2f;
	[ContextMenu ("execute")]
	public void execute(){
		transform.position=target.position;
	}
	void FixedUpdate(){
		transform.position+=(target.position-transform.position)*rate;
		
	}
}
