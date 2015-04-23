using UnityEngine;
using System.Collections;

public class TrnthAttackReceiver : TrnthHVSConditionAttackReceiver {
	void Update(){
		if(transform.position.y<-10000)onDie.send();
	}
}
