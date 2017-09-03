using UnityEngine;
using TRNTH;
public class TrnthFxShake:MonoBehaviour{
	public Transform target;
	public string findTarget;
	public bool reversed=true;
	public bool hasOrinPos=true; 
	public bool loop=false;
	public float time=0.1f;
	public float value=0.3f;
	public float noise=0.0f;
	public Space space=Space.Self;
	public AnimationCurve curve;
	public void play(){
		enabled=true;
		// a.s=time;
		_timeRecored=Time.time;
		Invoke("_start",time);
		_value=value+(Random.value)*noise;
		switch(space){
		case Space.World:posOrin=target.position;break;
		}
	}
	// TrnthAlarm a=new TrnthAlarm();
	// [SerializeField]
	float _timeRecored;
	Vector3 posOrin;
	float _value=0;
	void end(){
		if(!target)return;
		if(hasOrinPos){
			switch(space){
			case Space.Self:target.localPosition=posOrin;break;
			case Space.World:target.position=posOrin;break;
			}
		}
	}
	void Awake(){
		if(!target){
			var go=GameObject.Find(findTarget);
			if(go)target=go.transform;
		}
		if(!target)target=transform;
		switch(space){
		case Space.Self:posOrin=target.localPosition;break;
		}
	}
	void Start(){
		play();
	}
	void OnEnable(){
		play();
	}
	void OnDisable(){
		end();
	}
	void _start(){
		if(!loop){
			enabled=false;
		}
	}
	void Update(){
		var rate=(Time.time - _timeRecored) / time;
		// Vector3 vec=Random.insideUnitSphere*rate;
		Vector3 vec=Random.insideUnitSphere*curve.Evaluate(reversed?(1-rate):rate)*_value*Time.timeScale;
		if(hasOrinPos){
			switch(space){
			case Space.Self:target.localPosition=posOrin+vec;break;
			case Space.World:target.position=posOrin+vec;break;
			}
		}else{
			target.position+=vec;
		}
		// if(a.a&&!loop){
		// 	// Destroy(this);
		// 	enabled=false;
		// }
	}
}