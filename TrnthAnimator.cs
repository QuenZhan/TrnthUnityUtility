using UnityEngine;
using System.Collections;

public class TrnthAnimator : MonoBehaviour {
	public Animator animator;
	public TrnthAnimatorProxy proxy;
	public string parameterName="speed";
	public virtual void Awake(){
		if(!animator)animator=GetComponent<Animator>();
	}
	public void setup(){
		if(proxy)animator=proxy.animator;
		if(!animator)animator=GetComponent<Animator>();
	}	
	public virtual void execute(){
		// Debug.Log();
	} 
	void OnEnable(){
		setup();
		execute();
	}
}
