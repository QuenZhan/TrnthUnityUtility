﻿using UnityEngine;
using System.Collections;

public class TrnthAnimatorSpeed : TrnthAnimator {
	public TrnthCharacterControllerCreature ccc;
	void Update (){
		animator.SetFloat(parameterName,ccc.walkRate);
	}
}
