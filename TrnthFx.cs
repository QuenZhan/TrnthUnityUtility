using UnityEngine;
using TRNTH;
public class TrnthFx:MonoBehaviour{
	public string findIt;
	public float noise;
	public TrnthHVSCondition onEnd;

	public virtual void start(){
		enabled=true;		
		_timeStart=Time.time;
	}
	protected virtual void update(){
	}
	protected virtual void end(){
		enabled=false;
		if(onEnd)onEnd.send();
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