using UnityEngine;
using System.Collections;

public class TrnthEnabler : TrnthTriggerBase {
	public Behaviour target;
	public bool enable;
	public bool trigger;
	public override void execute(){
		target.enabled=enable;
		if(trigger)target.enabled=!enable;
	}
}
