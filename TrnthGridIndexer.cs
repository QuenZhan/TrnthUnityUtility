using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthGridIndexer : TrnthMonoBehaviour {
	public int index;
	public int margin=600;
	public float orgin=300;
	public float rate=0.2f;
	[ContextMenu("execute")]
	public void execute(){
		update(1);
	}
	public void update(float rate){
		var yy=orgin+index*margin;
		var vec=tra.localPosition;
		vec.y+=(yy-vec.y)*rate;
		tra.localPosition=vec;
	}
	void Update(){
		update(rate);
	}
}
