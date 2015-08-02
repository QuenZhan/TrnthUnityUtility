using UnityEngine;
using System.Collections;
public class TrnthFxIndexer : TrnthFx {
	[SerializeField]public int length=0;
	[SerializeField]public float margin=600;
	[SerializeField]public float orgin=0;
	[SerializeField]public float rate=0.2f;
	public event System.Action<TrnthFxIndexer,int> onChanged=delegate{};
	public int index{get{return _index;}set{_index=value;onChanged(this,_index);}}
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
		vec.y+=(yy-vec.y)*rate;	
		transform.localPosition=vec;
	}
	public void setRounded(){
		var delta=0f;
		delta=-transform.localPosition.y-orgin;
		index=(int)Mathf.Round(delta/margin);
		clamp();
	}
	public Vector3 localPositionAt(int index){
		var yy=orgin+index*margin;
		var vec=transform.localPosition;
		vec.y=yy;
		return vec;
	}
	public void clamp(){
		if(length!=0){
			if(index<0)index=0;
			if(index>=length)index=length-1;
		}
	}
	[ContextMenu("sort children by alphabet")]
	public void setup(){
		// var children=transform.Cast<Transform>().ToArray();
		// var q=from child in children
		// 	orderby child.name 
		// 	select child;
		// children=q.ToArray();
		// length=children.Length;
		// _setup(children);
	}
	Vector3 _vecDirection=Vector3.zero;
	protected Vector3 vecDirection{get{
		// if(_vecDirection!=Vector3.zero)return _vecDirection;
		var vec=Vector3.zero;
		vec=-Vector3.up;
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
	int _index;
}
