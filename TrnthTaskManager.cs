using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TrnthTaskManager : MonoBehaviour {
	static public void Add(Task<object> t,TaskCallback callback){
		if(_instance==null){
			var go=new GameObject("TrnthTaskManager");
			DontDestroyOnLoad(go);
			_instance=go.AddComponent<TrnthTaskManager>();
			_instance.start();
		}
		_instance.add(t,callback);
	}	
	static TrnthTaskManager _instance;
	public delegate void TaskCallback(Task<object> t);
	public void start(){
		Invoke("check",0.5f);
	}
	public void add(Task<object> t,TaskCallback callback){
		dic.Add(t,callback);
	}
	Dictionary<Task<object>,TaskCallback> dic=new Dictionary<Task<object>,TaskCallback>();
	void check(){
		foreach(var e in dic.Keys){
			if(e.IsCompleted){
				dic[e](e);
				dic.Remove(e);
			}
		}
		if(dic.Count>0)Invoke("check",0.5f);
	}
}
