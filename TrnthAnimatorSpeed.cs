using UnityEngine;
using System.Collections;

public class TrnthAnimatorSpeed : MonoBehaviour {
	public TrnthCharacterControllerCreature ccc;
	public Animator animator;
	public string parameterName="speed";
	void Awake(){
		if(!animator)animator=GetComponent<Animator>();
	}
	void Update (){
		animator.SetFloat(parameterName,ccc.walkRate);
	}
}
