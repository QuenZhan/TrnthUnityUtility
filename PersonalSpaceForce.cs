using UnityEngine;
using System.Collections;
namespace TRNTH{
[RequireComponent (typeof (Collider))]
public class PersonalSpaceForce:MonoBehaviour{
	public Creature creature;
	public float value=0.5f;
	void OnTriggerStay(Collider col){
		//Debug.Log("ddd");
		var vec=pos-col.transform.position;
		creature.vecForce+=vec.normalized*(collider.bounds.extents.magnitude-vec.magnitude)*value;
	}
}}
