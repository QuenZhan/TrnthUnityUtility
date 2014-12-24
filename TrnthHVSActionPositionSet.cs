using UnityEngine;
using System.Collections;

public class TrnthHVSActionPositionSet : TrnthHVSAction {
	public Transform target;
	public UnityEngine.Space space=Space.Self;
	public Vector3 pos;
	public Transform posWorld;
	protected override void _execute(){
		switch(space){
		case Space.Self:
			target.localPosition=pos;
			break;
		case Space.World:
			target.position=pos;
			break;
		}
		if(posWorld)target.position=posWorld.position;
	}
}
