using UnityEngine;
using System.Collections;

public class TrnthAttack : MonoBehaviour {
	public GameObject onReact;
	public float damageBase=30;
	public bool knockback;
	public bool showDamage=false;
	public virtual void react(float damage){
		if(onReact){
			onReact.SetActive(true);
			onReact.SetActive(false);			
		}
	}
	public virtual float damage{get{
		// var damage=damageBase;
		return damageBase;
	}}
}
