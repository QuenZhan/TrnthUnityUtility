using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthAlarm : MonoBehaviour {
	static public void Invoke(System.Action callback,float time){
		if(_instance==null){
			_instance=(new GameObject()).AddComponent<TrnthAlarm>();
		}
		_instance.start(callback,time);
	}
	static TrnthAlarm _instance;
	public void start(System.Action callback,float time){
		StartCoroutine(_start(callback,time));
	}
	IEnumerator _start(System.Action callback,float time){
		yield return new WaitForSeconds(time);
		callback();
	}
}
