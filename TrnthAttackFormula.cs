using UnityEngine;
using System.Collections;

public class TrnthAttackFormula{
	static public Result caculate(ITrnthAttackOffensive offensive,ITrnthAttackDefensive defensive){
		var result=new Result();
		result.criticalStrike=Random.value<offensive.criticalStrikeChance;
		if(result.criticalStrike)result.damage=offensive.damage*offensive.criticalStrikeScale;
		else result.damage=offensive.damage*(100f/(100f+defensive.resistence-offensive.penetration))- defensive.reduction;
		result.randomSeed=Random.value;
		if(result.damage<0)result.damage=0;
		return result;
	}
	public struct Result{
		public float damage;
		public bool criticalStrike;
		public float randomSeed;
		public IDSMControl control;
		public bool isHit;
		// public float timeControled;
	}
}