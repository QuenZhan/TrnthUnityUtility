using UnityEngine;
using System.Collections;

public abstract class TrnthConstraint : MonoBehaviour {
	public Transform target;
	public virtual void setup(){
		if(!target)target=transform;
	}
	public abstract void update();
	[ContextMenu("update")]
	public void contextMenuUpdate(){
		update();
	}
	void Awake(){
		setup();
	}
	void Update(){
		update();
	}
}
