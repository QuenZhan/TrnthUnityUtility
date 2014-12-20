using UnityEngine;
using System.Collections;

public class TrnthHVSActionActivate : TrnthHVSAction {
	public enum Mode{activate,deactivate,toggle}
	public GameObject target;
	public Mode mode;
	public bool trigger=true;
	public override string extraMsg{get{return "Activation";}}
	public override void execute(){
		base.execute();
		var yes=true;
		switch(mode){
		case Mode.activate:yes=true;break;
		case Mode.deactivate:yes=false;break;
		case Mode.toggle:yes=!target.activeSelf;break;
		}
		target.SetActive(yes);
		if(trigger)target.SetActive(!yes);
	}
}
