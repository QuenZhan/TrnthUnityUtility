using UnityEngine;
using System.Collections;

public class TrnthHVSActionCreatureVelCopy : TrnthHVSAction {
	public TrnthCreature copyFrom;
	public TrnthCreature copyTo;
	protected override void _execute(){
		copyTo.vecForce=copyFrom.vecForce;
	}
}
