using UnityEngine;
using System.Collections;

public class TrnthAnimatorSpeed : TrnthAnimator {
	public TrnthCreature ccc;
	void Update (){
		if(!ccc)enabled=false;
		else animator.SetFloat(parameterName,ccc.walkRate);
	}
}
