using UnityEngine;
using System.Collections;
using System.Linq;
public class TrnthGridIndexer : TrnthMonoBehaviour {
	public enum Directioin{ down,left,right,up}
	public int index;
	public int margin=600;
	public int length=0;
	public Directioin directioin;
	public float orgin=0;
	public float rate=0.2f;
	[ContextMenu("set to current index")]
	public void execute(){
		update(1);
	}
	public void update(float rate){
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
	}
	public void setRounded(){
		var delta=0f;
		switch(directioin){
		case Directioin.down	:delta=-tra.localPosition.y-orgin;break;
		case Directioin.up		:delta=tra.localPosition.y-orgin;break;
		case Directioin.right	:delta=-tra.localPosition.x-orgin;break;
		case Directioin.left	:delta=tra.localPosition.x-orgin;break;
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
		var vec=Vector3.zero;
		switch(directioin){
		case Directioin.down:vec=-Vector3.up;break;
		case Directioin.up:vec=Vector3.up;break;
		case Directioin.left:vec=-Vector3.right;break;
		case Directioin.right:vec=Vector3.right;break;
		}
		var children=transform.Cast<Transform>().ToArray();
		var q=from child in children
			orderby child.name 
			select child;
		children=q.ToArray();
		var childCount=children.Length;
		for(var i=0;i<childCount;i++){
			var child=children[i];
			child.localPosition=vec*i*margin;
		}
		length=childCount;
	}
	void Update(){
		update(rate);
	}
}
