using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrnthAnimatorReEntryOnEnable : MonoBehaviour {
	Animator _Animator;

	public void OnEnable(){
		if(_Animator==null)_Animator=GetComponent<Animator>();
		_Animator.Play(0);
//		_Animator.state
	}
	public void OnDisable(){

	}
}
