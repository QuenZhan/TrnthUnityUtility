using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TrnthPopulation : MonoBehaviour {
	public int max{get;private set;}
	public int sum;
	public int now{
		get{
			return _now;
		}set{
			var isChanged=false;
			if(_now!=value&&onChange!=null)isChanged=true;
			_now=value;
			if(value>max)max=value;
			if(isChanged)onChange();
			if(_now<1){
				onClear.send();
				countClear++;
			}
		}
	}
	public int countClear;
	[HideInInspector]
	public Transform locator;
	// public delegate void EHandler();
	public event System.Action onChange;
	public TrnthHVSCondition onClear;
	int _now=0;
	// void Start(){
		// onChange-=_onChange;
		// onChange+=_onChange;
	// }
	void _onChange(){
		if(now<1){
			onClear.send();
		}
	}
	// 安安
}