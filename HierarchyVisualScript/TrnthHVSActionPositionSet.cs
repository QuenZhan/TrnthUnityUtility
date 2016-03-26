using UnityEngine;
using System.Collections;

public class TrnthHVSActionPositionSet : TrnthHVSAction {
	public Transform target;
	// public UnityEngine.Space space=Space.Self;
	public Vector3 pos;
	public Transform posWorld;
	public string posWorldFind;
	public Vector3 noise;
	protected override void _execute(){
		var pos=this.pos+noise*Random.value;
		target.localPosition=pos;
		if(!posWorld&&posWorldFind!="")posWorld=GameObject.Find(posWorldFind).transform;
		if(posWorld)target.position=posWorld.position+noise*Random.value;
	}
}
