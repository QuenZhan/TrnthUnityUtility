using UnityEngine;
using System.Collections;

public class TrnthAnimatorSpeedVertical : TrnthAnimator {
	public TrnthCreature ccc;
	void Update (){
		animator.SetFloat(parameterName,ccc.rateFall);
	}
}
