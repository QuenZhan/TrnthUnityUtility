using UnityEngine;
using System.Collections;

public class TrnthFSM : MonoBehaviour {
	public TrnthHVSCondition onChange;
	public Component state;
	[ContextMenu("transit")]
	public virtual bool transit(Component state){
		if(this.state==state)return false;
		if(onChange)onChange.send();
		this.state=state;
		return true;
	}
}
