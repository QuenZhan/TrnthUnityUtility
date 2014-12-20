using UnityEngine;
using System.Collections;

public class TrnthModelBase : MonoBehaviour {
	public bool applyOnAwake=true;
	[ContextMenu("apply")]
	public void applyContextMenu(){
		apply();
	}
	public virtual void apply(){
		
	}
	void Awake(){
		if(applyOnAwake)apply();
	}
}
