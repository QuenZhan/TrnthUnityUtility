using UnityEngine;
using System.Collections;

public class TrnthHVSConditionAttackReceiver :  TrnthHVSCondition ,ITrnthAttackDefensive{
	[SerializeField] TrnthRadio hp;
	[SerializeField] MonoBehaviour forcer;
	[SerializeField] bool persistent;
	[SerializeField] float _resistence;

	public float point{get{return hp.value;}}
	public float resistence{get{return _resistence;}}

	public float hpBeforeHit{get;private set;}
	public ITrnthAttackOffensive attack{get;private set;}
	public virtual void hurtWith(ITrnthAttackOffensive attack,System.Action<TrnthHVSConditionAttackReceiver> react=null){
		this.attack=attack;
		var result=TrnthAttackFormula.caculate(attack,this);
		hpBeforeHit=hp.value;
		if(iForcer!=null){
			iForcer.addForce(attack.force);
		}
		hp-=result.damage;
		if(persistent&&hpBeforeHit>1&&hp.value<1)hp.value=1;
		hp.clamp();
		send();
	}
	ITrnthForcer iForcer;
	void Awake(){
		iForcer=forcer as ITrnthForcer;
	}
}
