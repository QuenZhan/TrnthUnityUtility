using UnityEngine;
using System.Collections;

public class TrnthInputDragRotate : MonoBehaviour {
	public int mouseButton=1;
	public float clickThreshold=0.2f;
	public float rate=1;
	public string state;
	void Update(){
		switch(state){
		case"draging":
			var delta=Input.mousePosition-_coor;
			transform.localEulerAngles=_angles+(new Vector3(-delta.y,delta.x,0))*rate;
			if(Input.GetMouseButtonUp(mouseButton)){
				if(!a.a){
					transform.localEulerAngles=Vector3.zero;
				}
				state="normal";
			}
			break;
		default:
			if(Input.GetMouseButtonDown(mouseButton)){
				_coor=Input.mousePosition;
				_angles=transform.localEulerAngles;
				state="draging";
				a.s=clickThreshold;
			}
			break;
		}
	}
	TrnthAlarm a=new TrnthAlarm();
	Vector3 _coor;
	Vector3 _angles;
}
