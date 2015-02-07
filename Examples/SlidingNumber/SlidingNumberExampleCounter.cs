
// adding slidingNumber.number 10 per second 

using UnityEngine;
using System.Collections;

public class SlidingNumberExampleCounter : MonoBehaviour {
	public TrnthSlidingNumber slidingNumber;
	void Start () {
		add();
	}
	void add(){
		slidingNumber.number+=1;
		Invoke("add",0.1f);
	}
}
