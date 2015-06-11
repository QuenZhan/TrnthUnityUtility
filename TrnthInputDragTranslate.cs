using UnityEngine;
using System.Collections;

public class TrnthInputDragTranslate : MonoBehaviour {
	public int mouseButton=2;
	public float clickThreshold=0.2f;
	public float rate=0.1f;
	public string state;
	void Update(){
		switch(state){
		case"draging":
			var delta=Input.mousePosition-_coor;
			transform.localPosition=_pos+(new Vector3(-delta.x,-delta.y,0)*rate);
			if(Input.GetMouseButtonUp(mouseButton)){
				state="normal";
			}
			break;
		default:
			if(Input.GetMouseButtonDown(mouseButton)){
				_coor=Input.mousePosition;
				_pos=transform.localPosition;
				state="draging";
			}
			break;
		}
	}
	Vector3 _coor;
	Vector3 _pos;
}
