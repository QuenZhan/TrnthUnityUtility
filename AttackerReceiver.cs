using UnityEngine;
namespace TRNTH{
[RequireComponent(typeof(Collider))]
public class AttackerReceiver:MonoBehaviour{
	public float cd=0.3f;
	public Creature creature;
	public virtual bool receive(Attacker attacker){
		// Debug.Log(attacker.name);
		if(!a.a)return false;
		a.s=cd;
		// _collider.enabled=false;
		if(creature)creature.play("hurt");
		return true;
	}
	Collider _collider;
	Alarm a=new Alarm();
	void Awake(){
		_collider=collider;
	}
	void OnSpawned(){
		a.s=cd;		
	}
}
}