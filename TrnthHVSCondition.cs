using UnityEngine;
using System.Collections;

public class TrnthHVSCondition : TrnthHVS {
	public virtual void execute(){
		log();
		if(callback!=null)callback();
	}
	public delegate void Callback();
	public event Callback callback;
}
