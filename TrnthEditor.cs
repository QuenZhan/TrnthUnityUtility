using UnityEngine;
using System.Collections;
using System.Linq;

public class TrnthEditor : MonoBehaviour {

	[ContextMenu("clear")]
	public void clear(){
		foreach(Transform e in transform.Cast<Transform>().ToArray()){
			DestroyImmediate(e.gameObject);
		}
	}
}
