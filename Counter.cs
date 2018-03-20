using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public class Counter  {
		public float Duration{ get; private set; }
		public bool Running{get{return _TimeRecored!=Mathf.NegativeInfinity;}}
		public void Start(float duration){
			this.Duration = duration;
			Reset ();
		}
		public virtual void Reset(){
			_TimeRecored = 0;
		}
		public virtual void Stop(){
			_TimeRecored=Mathf.NegativeInfinity;
		}
		public virtual void Update(float deltaTime){
			_TimeRecored += deltaTime;
			if (_TimeRecored <Duration ) return ;
			Stop();
			Timesup();
		}
		protected virtual void Timesup(){
			
		}
		public float TimeSinceStart{get{return _TimeRecored;}}
		float _TimeRecored=Mathf.NegativeInfinity;
	}
}