using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthCoroutine : MonoBehaviour {
	static public Coroutine Wait(System.Func<bool> predicate){
		return Coroutine(CoroutinePredicate(predicate));
	}
	static public Coroutine WaitForRealtimeSeconds(float duration){
		return Coroutine(CoroutineInRealtime(duration));
	}
	static public Coroutine WaitForLocalTimeScale(float duration,System.Func<float> timeScale){
		return Coroutine(CoroutineInLocalScale(duration,timeScale));
	}
	static IEnumerator CoroutineInLocalScale(float duration,System.Func<float> timeSpeed){
		var localTime=0f;
		while(localTime<duration){
			yield return null;
			localTime+=Time.deltaTime*timeSpeed();
		}
	}
	public static IEnumerator CoroutineInRealtime(float duration){
		var localTime=0f;
		while(localTime<duration){
			yield return null;
			localTime+=Time.unscaledDeltaTime;
		}
	}
	static IEnumerator CoroutinePredicate(System.Func<bool>predicate){
		while(!predicate()){
			yield return new WaitForSeconds(0);
		}
	}
	static public void Replace(ref IEnumerator old,IEnumerator theNew){
		Cancel(old);
		old=theNew;
		Coroutine(old);
	}
	static public void Cancel(IEnumerator routine){
		if(routine==null)return;
		checkInstance();
		_instance.cancel(routine);
	}
	static public void Cancel(System.Action callback){
		checkInstance();
		_instance.cancel(callback);
	}
	static public void Invoke(System.Action callback,float time){
		checkInstance();
		_instance.start(callback,time);
	}
	static public Coroutine Coroutine(IEnumerator c){
		checkInstance();
		return _instance.coroutine(c);
	}
	static void checkInstance(){
		if(_instance==null){
			_instance=(new GameObject("TrnthAlarm")).AddComponent<TrnthCoroutine>();
//			DontDestroyOnLoad(_instance.gameObject);
		}
	}
	public static TrnthCoroutine Instance{get{return _instance;}}
	static TrnthCoroutine _instance;
	internal Dictionary<System.Action,float> _queue=new Dictionary<System.Action,float>();
	internal void start(System.Action callback,float time){
		StartCoroutine(_start(callback,time));
	}
	internal Coroutine coroutine(IEnumerator c){
		return StartCoroutine(c);
	}
	internal void cancel(IEnumerator routine){
		StopCoroutine(routine);
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
