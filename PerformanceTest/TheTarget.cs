using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheTarget : MonoBehaviour {
	const string SoHurtttt="SoHurtttt";
	public Collider2D Collider;
	public int count=0;
	void Update(){
		count=0;
	}
	public int Hurt(){
		count++;
		return count;
//		Debug.Log(SoHurtttt);

	}
}
