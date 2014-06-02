using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthAntennaAnimatorCccForce : TrnthAntennaAnimatorCcc{
	public Vector3 force;
	public Vector3 forceLocal;
	public float delayForce;
	public float cooldown=0.3f;
	public bool flag=true;
	public CollisionFlags collisionFlag;
	public TrnthAntenna[] antennasOff;
	public void execute(){
		if(!a.a)return;
		// Debug.Log(ccc.ccr.isGrounded);
		if (flag&&(ccc.ccr.collisionFlags & collisionFlag) == 0)return;
		if(!isOff())return;
		trigger();
		a.s=cooldown;
		Invoke("_execute",delayForce);
	}
	Alarm a=new Alarm();
	bool isOff(){
		foreach(TrnthAntenna e in antennasOff){
			if(e.isTriggerStay)return false;
		}
		return true;
	}
	void _execute(){
		// Debug.Log("_execute");
		// CancelInvoke();
		// Invoke("active",cooldown);
		ccc.vecForce=force+ccc.transform.TransformDirection(forceLocal);
	}
	void OnTriggerStay(Collider col){
		// Debug.Log(col.name);
		execute();
	}
}
