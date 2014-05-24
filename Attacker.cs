using UnityEngine;
namespace TRNTH{
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Attacker:MonoBehaviour{
	Collider _collider;
	Rigidbody _rigidbody;
	void Awake(){
		_collider=collider;
		_rigidbody=rigidbody;
	}
	public virtual void OnTriggerEnter(Collider col){
		// Debug.Log(col.name);
		AttackerReceiver ar=col.GetComponent<AttackerReceiver>();
		if(ar){
			ar.receive(this);
			// _collider.enabled=false;
		}
	}
}
}