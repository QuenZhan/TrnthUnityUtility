using UnityEngine;
public class TrnthEditorDestroyRuntime : MonoBehaviour {
	void Awake(){
		Destroy(this);
		// gameObject.SetActive(false);
	}
}
