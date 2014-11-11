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
			_now=value;
			// sum+=1;
			if(value>max)max=value;
		}
	}
	int _now=0;
}
