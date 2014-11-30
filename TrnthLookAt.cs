using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthLookAt : MonoBehaviour {
	public Transform self;
	public Transform target;
	public bool yOnly=false;
	void Update () {
		if(!target)return;
		var vec=target.position;
		if(yOnly)vec.y=self.position.y;
		self.LookAt(vec);
	}
}
