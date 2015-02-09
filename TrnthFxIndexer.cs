using UnityEngine;
using System.Collections;
using System.Linq;
public class TrnthFxIndexer : TrnthFx {
	public enum Directioin{down,left,right,up}
	public Directioin directioin;
	public int index;
	public int length=0;
	public float margin=600;
	public float orgin=0;
	public float rate=0.2f;
	[ContextMenu("set to current index")]
	public void execute(){
		update(1);
	}
	protected override void  update(){
		base.update();
		update(rate);
	}
	protected virtual void update(float rate){
		clamp();
		var yy=orgin+index*margin;
		var vec=transform.localPosition;
		switch(directioin){
		case Directioin.up:
			yy=orgin-index*margin;
			vec.y+=(yy-vec.y)*rate;	
			break;
		case Directioin.down:
			vec.y+=(yy-vec.y)*rate;	
			break;
		case Directioin.left:
			vec.x+=(yy-vec.x)*rate;
			break;
		case Directioin.right:
			yy=orgin-index*margin;
			vec.x+=(yy-vec.x)*rate;
			break;
		}
		transform.localPosition=vec;
		// childSetup(transform,vec);
	}
	public void setRounded(){
		var delta=0f;
		switch(directioin){
		case Directioin.down	:delta=-transform.localPosition.y-orgin;break;
		case Directioin.up		:delta=transform.localPosition.y-orgin;break;
		case Directioin.right	:delta=-transform.localPosition.x-orgin;break;
		case Directioin.left	:delta=transform.localPosition.x-orgin;break;
		}
		// Debug.Log(delta);
		index=(int)Mathf.Round(delta/margin);
		clamp();
	}
	public void clamp(){
		if(length!=0){
			if(index<0)index=0;
			if(index>=length)index=length-1;
		}
	}
	[ContextMenu("sort children by alphabet")]
	public void setup(){
		var children=transform.Cast<Transform>().ToArray();
		var q=from child in children
			orderby child.name 
			select child;
		children=q.ToArray();
		length=children.Length;
		_setup(children);
	}
	Vector3 _vecDirection=Vector3.zero;
	protected Vector3 vecDirection{get{
		// if(_vecDirection!=Vector3.zero)return _vecDirection;
		var vec=Vector3.zero;
		switch(directioin){
		case Directioin.down:vec=-Vector3.up;break;
		case Directioin.up:vec=Vector3.up;break;
		case Directioin.left:vec=-Vector3.right;break;
		case Directioin.right:vec=Vector3.right;break;
		}
		_vecDirection=vec;
		return _vecDirection;
	}}
	protected virtual void _setup(Transform[] children){		
		var vec=vecDirection;
		var childCount=children.Length;
		for(var i=0;i<childCount;i++){
			var child=children[i];
			child.localPosition=vec*i*margin;
		}
	}
	protected virtual void childSetup(Transform child,Vector3 direction){}
}
