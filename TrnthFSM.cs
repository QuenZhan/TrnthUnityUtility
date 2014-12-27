using UnityEngine;
using System.Collections;

public class TrnthFSM : MonoBehaviour {
	public TrnthHVSCondition onChange;
	public Component state;
	[ContextMenu("transit")]
	public virtual bool transit(Component state){
		if(this.state==state)return false;
		this.state=state;
		if(onChange)onChange.send();
		return true;
	}
}
