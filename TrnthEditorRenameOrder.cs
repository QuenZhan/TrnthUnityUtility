using UnityEngine;
using System.Collections;

public class TrnthRenameOrder : MonoBehaviour {
	public string prefix="renamed : ";
	[ContextMenu("execute")]
	public void execute(){
		var index=0;
		foreach(Transform e in transform){
			e.name=prefix+index;
			index++;
		}
	}
}
