using UnityEngine;
using System.Collections;
public class TrnthGridIndexer : TrnthMonoBehaviour {
	public enum Directioin{ down,left,right,up}
	public int index;
	public int margin=600;
	public int length=0;
	public Directioin directioin;
	public float orgin=300;
	public float rate=0.2f;
	[ContextMenu("execute")]
	public void execute(){
		update(1);
	}
	public void update(float rate){
		clamp();
		var yy=orgin+index*margin;
		var vec=tra.localPosition;
		switch(directioin){
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
		tra.localPosition=vec;
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
	void Update(){
		update(rate);
	}
}
