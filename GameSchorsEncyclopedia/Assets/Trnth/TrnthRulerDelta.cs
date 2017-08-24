using UnityEngine;
using System.Collections;

public class TrnthRulerDelta : MonoBehaviour {
	public Transform tra1;
	public Transform tra2;
	public Vector3 delta;
	void Update () {
		delta=tra1.position-tra2.position;
	}
}
