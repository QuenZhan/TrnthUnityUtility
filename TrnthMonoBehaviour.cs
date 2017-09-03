using UnityEngine;
using System.Collections.Generic;
public class TrnthMonoBehaviour:UnityEngine.MonoBehaviour{
	internal Transform tra{get;private set;}
	internal GameObject gobj{get;private set;}
	public virtual void Awake(){
		tra=transform;
		gobj=gameObject;
	}
	public Vector3 Position{
		get{
			if(!tra)tra=transform;
			return tra.position;
		}
		set{
			if(!tra)tra=transform;
			tra.position=value;
		}
	}
}