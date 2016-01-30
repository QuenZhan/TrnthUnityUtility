using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthAlarm : MonoBehaviour {
	static public void Cancel(System.Action callback){
		_instance.cancel(callback);
	}
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
	internal Dictionary<System.Action,float> _queue=new Dictionary<System.Action,float>();
	internal void start(System.Action callback,float time){
		// _queue[key]=callback;
		StartCoroutine(_start(callback,time));
	}
	internal void coroutine(IEnumerator c){
		// StopCoroutine(c);
		StartCoroutine(c);
	}
	internal void cancel(System.Action callback){
		_queue[callback]=0;
	}
	IEnumerator _start(System.Action callback,float time){
		var record=Random.value+Time.time;
		_queue[callback]=record;
		yield return new WaitForSeconds(time);
		if(_queue[callback]!=record)yield break;
		callback();
	}
}
