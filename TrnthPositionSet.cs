using UnityEngine;
using System.Collections;

public class TrnthPositionSet : TrnthTriggerBase {
	public Transform target;
	public UnityEngine.Space space=Space.Self;
	public Vector3 pos;
	public override void execute(){
		switch(space){
		case Space.Self:
			target.localPosition=pos;
			break;
		case Space.World:
			target.position=pos;
			break;
		}
	}
}
