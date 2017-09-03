using UnityEngine;
using System.Collections;

public class TrnthRandomRotation : MonoBehaviour {

	void OnEnable () {
		transform.eulerAngles=new Vector3(Random.value*360,Random.value*360,Random.value*360);
	}
}
