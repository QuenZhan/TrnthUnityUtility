using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthGridIndexer : TrnthMonoBehaviour {
	public enum Directioin{ down,left,right,up}
	public int index;
	public int margin=600;
	public Directioin directioin;
	public float orgin=300;
	public float rate=0.2f;
	[ContextMenu("execute")]
	public void execute(){
		update(1);
	}
	public void update(float rate){
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
	void Update(){
		update(rate);
	}
}
