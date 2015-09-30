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
	public abstract IDSTeamReport report{get;}
	public abstract IDSTeamMember member{get;}

	public virtual float damage{get{
		// var damage=damageBase;
		return damageBase+Random.value*damageNoise;
	}}
	public float penetration{get;set;}
	public float criticalStrikeChance{get{return 0.08f;}}
	public float criticalStrikeScale{get;set;}
	
	public string control{get{
		if(System.Array.Exists(_tags,t=>{return t=="scartter";}))return "scartter";
		if(System.Array.Exists(_tags,t=>{return t=="blowaway";}))return "blowaway";
		if(System.Array.Exists(_tags,t=>{return t=="faint";}))return "faint";
		if(System.Array.Exists(_tags,t=>{return t=="repel";}))return "repel";
		if(System.Array.Exists(_tags,t=>{return t=="hurt";}))return "hurt";
		if(System.Array.Exists(_tags,t=>{return t=="bother";}))return "bother";
		return "";
	}}
	public string[] tags{
		get{
			return _tags;
		}
		set{
			_tags=value;
		}
	}

	public Vector3 force{get;set;}
	public bool showDamage{get{return _showDamage;}}

	public Transform tra{get{return this.transform;}}
	public Vector3 position{get{return this.transform.position;}}

	public TrnthHVSActionSpawn[] attachments;
	public virtual void react(ITrnthAttackDefensive defensive){
		this.send(conditionReact);
		if(onReact){
			onReact.SetActive(true);
			onReact.SetActive(false);			
		}
	}
	public virtual void attach(Transform tra){
		foreach(var spawner in attachments){
			spawner.transform.position=tra.position;
			spawner.execute();
		}
	}
}
