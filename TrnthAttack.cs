using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using TRNTH;
public class TrnthAttack : MonoBehaviour,ITrnthAttackOffensive {
	[SerializeField]TrnthHVSCondition conditionReact;
	[SerializeField]string[] _tags;
	[FormerlySerializedAsAttribute("showDamage")]
	[SerializeField]bool _showDamage=false;
	[SerializeField]public float damageBase=30;
	[SerializeField]public float damageNoise=10;
	[SerializeField]public bool knockback;

	[HideInInspector]public GameObject onReact; // obsolute
	public virtual float damage{get{
		// var damage=damageBase;
		return damageBase+Random.value*damageNoise;
	}}
	public float penetration{get;set;}
	public float criticalStikeChance{get{return 0.2f;}}
	public float criticalStikeScale{get{return 2;}}
	
	public string[] tags{
		get{
			// var z = new string[x.Length + y.Length];
			// x.CopyTo(z, 0);
			// y.CopyTo(z, x.Length);
			if(knockback){
				var list=new List<string>(_tags);
				list.RemoveAll(s=>{return s=="repel";});
				list.Add("repel");
				_tags=list.ToArray();
				// _array[0]="repel";
				// _tags.CopyTo(_array,1);
				// _tags=_array;
			}
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
			// if(!spawner.spawned)continue;
			// var constraint=spawner.spawned.GetComponent<TrnthConstraintPosition>();
			// if(!constraint)constraint=spawner.spawned.gameObject.AddComponent<TrnthConstraintPosition>();
			// constraint.position=tra;
		}
	}
}
