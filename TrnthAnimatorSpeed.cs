using UnityEngine;
using System.Collections;

public class TrnthAnimatorSpeed : TrnthAnimator {
	public TrnthCreature ccc;
	void Update (){
		animator.SetFloat(parameterName,ccc.walkRate);
	}
}
