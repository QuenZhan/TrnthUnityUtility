using UnityEngine;
using System.Collections;
namespace TRNTH{
public class Rogdoll : MonoBehaviour {
	public Rigidbody[] rigidbodies;
	public Animator animator;
	[ContextMenu ("inactivate")]
	public void inactivate(){
		toggle(false);
	}
	[ContextMenu ("activate")]
	public void activate(){
		toggle(true);		

	}
	[ContextMenu ("collect")]
	public void collect(){
		//transform
	}
	void toggle(bool yes){
		foreach(var rigid in rigidbodies){
			rigid.isKinematic=!yes;
			rigid.GetComponent<Collider>().enabled=yes;
			rigid.gameObject.layer=17;
		}
		if(animator)animator.enabled=!yes;

	}
	void OnDestroy(){
		toggle(true);
		// foreach(var rigid in rigidbodies){
		// 	rigid.AddExplosionForce(1000,transform.position-Vector3.up*1.1f,5);
		// }
	}
}
	
}
