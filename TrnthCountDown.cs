using UnityEngine;
using System.Collections;

public class TrnthCountDown : MonoBehaviour {
	public UILabel label;
	public float second;
	void update(){
		second-=1;
		label.text=second+"";
		if(enabled)Invoke("update",1);
	}
	void Start(){
		update();
	}
}
