using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthRadioTransform : TrnthRadio {
	public Transform background;
	public Transform foreground;
	void Update(){
		foreground.localScale=new Vector3(rate,1,1);
	}
}
