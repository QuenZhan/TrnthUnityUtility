using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using TRNTH;
public abstract class TrnthAttack : MonoBehaviour,ITrnthAttackOffensive {
	[SerializeField]TrnthHVSCondition conditionReact;
	[SerializeField]string[] _tags;
	[FormerlySerializedAsAttribute("showDamage")]
	[SerializeField]bool _showDamage=false;
	[SerializeField]public float damageBase=30;
	[SerializeField]public float damageNoise=10;
	[HideInInspector]public GameObject onReact; // obsolute
	public float whiteCriticalStrikeChance=0.08f;
	public abstract IDSTeamReport report{get;}
	public abstract IDSTeamMember member{get;}

	public virtual float damage{get{
		return damageBase+Random.value*damageNoise;
	}}
	public virtual float penetration{get;set;}
	public virtual float criticalStrikeChance{get{return whiteCriticalStrikeChance;}}
	public virtual float criticalStrikeScale{get;set;}
	
	public abstract string control{get;set;}
	public virtual string[] tags{get{return _tags;}set{_tags=value;}}
	public Vector3 force{get;set;}
	public bool showDamage{get{return _showDamage;}}

	public Transform tra{get{return this.transform;}}
	public virtual Vector3 position{get{return this.transform.position;}}

	public TrnthHVSActionSpawn[] attachments;
	public virtual void react(ITrnthAttackDefensive defensive){
		this.send(conditionReact);
		if(onReact){
			onReact.SetActive(true);
			onReact.SetActive(false);			
		}
	}
	public abstract bool contains(string tag);
	public abstract float value(string tag);
	public virtual void attach(Transform tra){
		foreach(var spawner in attachments){
			spawner.transform.position=tra.position;
			spawner.execute();
		}
	}
}
