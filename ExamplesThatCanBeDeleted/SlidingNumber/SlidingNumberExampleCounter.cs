
// adding slidingNumber.number 10 per second 

using UnityEngine;
using System.Collections;

public class SlidingNumberExampleCounter : MonoBehaviour {
	public TrnthFxSlidingNumber slidingNumber;
	void Start () {
		add();
	}
	void add(){
		slidingNumber.number+=1;
		Invoke("add",0.1f);
	}
	// void Update(){
		// slidingNumber.number+=Time.deltaTime;
	// }
}
