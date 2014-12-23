using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrnthHVSActionActivate : TrnthHVSAction {
	public enum Mode{activate,deactivate,toggle}
	public enum Target{self,allChildren,parent}
	public GameObject target;
	public Mode mode;
	public Target who;
	public bool trigger=true;
	public override string extraMsg{get{return "Activation";}}
	protected override void _execute(){
		base._execute();
		var yes=true;
		switch(mode){
		case Mode.activate:yes=true;break;
		case Mode.deactivate:yes=false;break;
		case Mode.toggle:yes=!target.activeSelf;break;
		}
		var targets=new GameObject[]{this.target};
		switch(who){
		case Target.allChildren:
			var list=new List<GameObject>();
			foreach(Transform e in target.transform){
				list.Add(e.gameObject);
			}
			targets=list.ToArray();
			break;
		case Target.parent:
			targets=new GameObject[]{target.transform.parent.gameObject};
			break;
		}
		foreach(var e in targets){
			e.SetActive(yes);
		}
		if(trigger)target.SetActive(!yes);
	}
}
