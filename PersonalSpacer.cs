using UnityEngine;
using System.Collections;
namespace TRNTH{
[RequireComponent (typeof (Collider))]
public class PersonalSpacer:MonoBehaviour{
	public CharacterControllerCreature creature;
	public float value=0.5f;
	void OnTriggerStay(Collider col){
		var ps=col.GetComponent<PersonalSpacer>();
		if(!ps)return;
		var vec=pos-col.transform.position;
		creature.vecForce+=vec.normalized*(collider.bounds.extents.magnitude-vec.magnitude)*value;
	}
}}
