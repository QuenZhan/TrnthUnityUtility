using UnityEngine;
using System.Collections;

public class TrnthBoucingNumber : MonoBehaviour {
	public TextMesh[] textMeshes;
    public Transform theOwner { get { return _owner; } }
    Transform _owner;
    public void setup(int number, Transform owner)
    {
		foreach(var textMesh in textMeshes){
			textMesh.text=number+"";
		}
	}

    public void miss(Transform owner) // Nori, 跳miss
    {
        _owner = owner;
        
        foreach (var textMesh in textMeshes)
        {
            textMesh.text = "MISS";
        }
        return;
 
    }
}
