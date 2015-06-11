using UnityEngine;
using System.Collections;

public class TrnthInputScale : MonoBehaviour {
	public int mouseButton=2;
	public string axisname="Mouse ScrollWheel";
	public float rate=0.5f;
	public float smoothTime=1;
	public float wheel{set{_wheel=value;}}
	void Update () {
		var wheel=-Input.GetAxis(axisname);
		_wheel+=wheel*rate;
		if(_wheel<0.1f)_wheel=0.1f;
		_current=Mathf.SmoothDamp(_current,_wheel,ref _vel,smoothTime);
		transform.localScale=Vector3.one*(_current);
		// if(Input.GetMouseButtonDown(mouseButton)){
		// 	a.s=0.1f;
		// }
		if(
			// !a.a&&
			Input.GetMouseButtonUp(mouseButton)){
			_wheel=1;			
		}
	}
	float _wheel=1;
	float _current=1;
	float _vel=1;
}
