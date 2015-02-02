using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthConstraintFixedUpdate : MonoBehaviour {
	public Transform target;
	public float rate=0.2f;
	public bool fixedUpdate;

	[ContextMenu ("execute")]
	public void execute(){
		transform.position=target.position;
	}
	public virtual void update(Vector3 pos){
		transform.position+=(pos-transform.position)*rate;
	}
	void FixedUpdate(){
		if(fixedUpdate)update(target.position);
	}
	void Update(){
		if(!fixedUpdate)update(target.position);
	}
}
