using UnityEngine;
using System.Collections;

public class TrnthModelBase : MonoBehaviour {
	public bool synced=true;
	[ContextMenu("apply")]
	public void applyContextMenu(){
		apply();
	}
	public virtual void apply(){
		//do nothing exactly
	}
	void Awake(){
		if(synced)apply();
	}
}
