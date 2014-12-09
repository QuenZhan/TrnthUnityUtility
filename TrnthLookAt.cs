using UnityEngine;
using System.Collections;
// [ExecuteInEditMode]
public class TrnthLookAt : MonoBehaviour {
	public Transform self;
	public Transform target;
	public string findTarget;
	public bool yOnly=false;
	void find(){
		var go=GameObject.Find(findTarget);
		if(go)target=go.transform;
	}
	[ContextMenu("update")]
	void Update () {
		if(!target)return;
		var vec=target.position;
		if(yOnly)vec.y=self.position.y;
		self.LookAt(vec);
	}
	void OnEnable(){
		if(!target)find();
		Update();
	}
}
