using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthEditor : MonoBehaviour {

	[ContextMenu("children clear")]
	public void clear(){
		foreach(Transform e in transform.Cast<Transform>().ToArray()){
			DestroyImmediate(e.gameObject);
		}
	}
}
