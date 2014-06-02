using UnityEngine;
using System.Collections.Generic;
using TRNTH;
public class TrnthMotionExecuter : TRNTH.MonoBehaviour {
	public Animator animator;
	public TrnthCharacterControllerCreature ccc;
	public void add(TrnthMotion motion){
		if(!a.a)return;
		enabled=true;
		list.Add(motion);
	}
	public void execute(TrnthMotion motion){
		if(!motion)return;
		if(!a.a)return;
		Invoke("_force",motion.delayForce);
		Invoke("_animator",motion.delayAnimator);
		a.s=motion.cooldown;		
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
		enabled=false;
	}
	TrnthMotion motion;
	List<TrnthMotion> list=new List<TrnthMotion>();
	Alarm a=new Alarm();
	void _force(){
		ccc.vecForce=motion.forceWorld+ccc.transform.TransformDirection(motion.forceLocal);
	}
	void _animator(){
		animator.SetTrigger(motion.animatorParameter);
	}	
	void Update(){
		motion=chooseMotion();
		execute(motion);
		clear();
	}
}
