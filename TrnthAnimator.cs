using UnityEngine;
using System.Collections;

public class TrnthAnimator : MonoBehaviour {
	public Animator animator;
	public string parameterName="speed";
	public virtual void Awake(){
		if(!animator)animator=GetComponent<Animator>();
	}
}
