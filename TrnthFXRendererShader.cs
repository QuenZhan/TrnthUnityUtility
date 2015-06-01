using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthFXRendererShader : MonoBehaviour {
	public Renderer rdr;
	public Shader shader;
	public float duration=0.1f;
	public virtual void start(){
		memorize();
		foreach(var e in rdr.materials){
			e.shader=shader;
		}
		Invoke("end",duration);
	}
	protected virtual void end(){
		foreach(var e in rdr.materials){
			e.shader=dic[e];
		}
		enabled=false;
	}
	Dictionary<Material,Shader> dic=new Dictionary<Material,Shader>();
	void memorize(){
		dic.Clear();
		foreach(var e in rdr.materials){
			dic.Add(e,e.shader);
		}
	}
	void OnEnable(){
		start();
	}

}
