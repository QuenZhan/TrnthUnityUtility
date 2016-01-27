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
	static public void Coroutine(IEnumerator c){
		_instance.coroutine(c);
	}
	static TrnthAlarm _instance;
	internal void start(System.Action callback,float time){
		// StopCoroutine("_start");
		StartCoroutine(_start(callback,time));
	}
	internal void coroutine(IEnumerator c){
		// StopCoroutine(c);
		StartCoroutine(c);
	}
	IEnumerator _start(System.Action callback,float time){
		yield return new WaitForSeconds(time);
		callback();
	}
}
