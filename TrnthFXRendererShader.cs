using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthFXRendererShader : MonoBehaviour {
	public Renderer rdr;
	public Shader shader;
	public float duration=0.1f;
	public virtual void start(){
		if(rdr==null)return;
		memorize();
		foreach(var e in rdr.materials){
			e.shader=shader;
		}
		Invoke("end",duration);
	}
	protected virtual void end(){
		if(rdr==null || dic.Count<1)return;
		foreach(var e in rdr.materials){
			if(!dic.ContainsKey(e))continue;
			e.shader=dic[e];
		}
		enabled=false;
	}
	Dictionary<Material,Shader> dic=new Dictionary<Material,Shader>();
	void memorize(){		
		dic.Clear();
		foreach(var e in rdr.materials){
			dic[e]=e.shader;
		}
	}
	protected void OnEnable(){
		// start();
	}
	protected void OnDisable(){
		// end();
		CancelInvoke();
	}

}
