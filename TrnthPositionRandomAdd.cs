using UnityEngine;
using System.Collections;

public class TrnthPositionRandomAdd : TrnthMonoBehaviour {
	public float radius;
	public void execute(){
		pos=pos+Random.insideUnitSphere*radius;
	}
	void OnEnable(){
		execute();
	}
}
