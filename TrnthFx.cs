using UnityEngine;
using TRNTH;
public class TrnthFx:MonoBehaviour{
	public string findIt;
	public float noise;
	public virtual void start(){
		enabled=true;		
		_timeStart=Time.time;
	}
	protected virtual void update(){
	}
	protected void end(){
		enabled=false;
	}
	protected float _timeStart;
	void OnEnable(){
		start();
	}
	void OnDisable(){
		CancelInvoke();
	}
	void Update(){
		update();
	}
}