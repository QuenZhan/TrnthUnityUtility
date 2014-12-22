using UnityEngine;
using System.Collections;

public class TrnthHVS : MonoBehaviour {
	public bool debugLog;
	public virtual string extraMsg{get{return"";}}
	protected virtual void log(){
		if(debugLog){
			var parentName="";
			if(transform.parent)parentName=transform.parent.name+"/";
			Debug.Log(transform.root.name+"/../"+parentName+name+" TrnthHVS"+" ,"+extraMsg);
		}
	}
}
