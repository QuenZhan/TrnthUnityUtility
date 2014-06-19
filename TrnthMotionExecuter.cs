using UnityEngine;
using System.Collections.Generic;
using TRNTH;
public class TrnthMotionExecuter : TrnthMonoBehaviour {
	public Animator animator;
	public TrnthCreature ccc;
	public void add(TrnthMotion motion){
		//if(!a.a)return;
		enabled=true;
		list.Add(motion);
	}
	public void execute(TrnthMotion motion){
		if(!motion)return;
		if(!a.a)return;
		if(motion.toDeactivate){
			motion.toDeactivate.SetActive(false);
			Invoke("_deactivate",motion.cooldown);
		}
		forceWorld=motion.forceWorld;
		forceLocal=motion.forceLocal;
		animatorParameter=motion.animatorParameter;
		Invoke("_force",motion.delayForce);
		Invoke("_animator",motion.delayAnimator);
		a.s=0.4f;
		motion.executed();
	}
	public TrnthMotion chooseMotion(){
		if(list.Count<1)return null;
		motion=list[0];
		foreach(TrnthMotion e in list.ToArray()){
			if(e.priority>motion.priority)motion=e;
		}
		return motion;
	} 
	public void clear(){
		list.Clear();
		motion=null;
		enabled=false;
	}
	TrnthMotion motion;
	List<TrnthMotion> list=new List<TrnthMotion>();
	Vector3 forceWorld;
	Vector3 forceLocal;
	string animatorParameter;
	Alarm a=new Alarm();
	void _force(){
		ccc.vecForce=forceWorld+ccc.transform.TransformDirection(forceLocal);
	}
	void _animator(){
		if(!animator)return;
		animator.SetTrigger(animatorParameter);
	}
	void _deactivate(){
		if(!motion.toDeactivate)return;
		motion.toDeactivate.SetActive(true);
	}
	void Update(){
		motion=chooseMotion();
		execute(motion);
		clear();
	}
}
