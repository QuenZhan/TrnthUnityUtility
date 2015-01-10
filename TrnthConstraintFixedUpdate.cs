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
	public virtual void update(Vector3 pos){
		transform.position+=(pos-transform.position)*rate;
	}
	void FixedUpdate(){
		update(target.position);
	}
}
