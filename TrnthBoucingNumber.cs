using UnityEngine;
using System.Collections;

public class TrnthBoucingNumber : MonoBehaviour {
	public TextMesh[] textMeshes;
	// public UILabel label;
	public void setup(int number){
		foreach(var textMesh in textMeshes){
			textMesh.text=number+"";
		}
		// if(label)label.text=number+"";
	}
}
