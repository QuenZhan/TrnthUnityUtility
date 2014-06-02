using UnityEngine;
using System.Collections;

public class TrnthAnimatorSpeedVertical : TrnthAnimator {
	public TrnthCharacterControllerCreature ccc;
	void Update (){
		animator.SetFloat(parameterName,ccc.rateFall);
	}
}
