using UnityEngine;
using System.Collections;

public class TrnthCountDown : MonoBehaviour {
	public UILabel label;
	public float second;
	void update(){
		second-=1;
		int min=(int)(second/60);
		int sec=(int)(second%60);
		label.text=(min<10?"0":"")+min+":"+(sec<10?"0":"")+sec;
		if(enabled)Invoke("update",1);
	}
	void Start(){
		update();
	}
}
