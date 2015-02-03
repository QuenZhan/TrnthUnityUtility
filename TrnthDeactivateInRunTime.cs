using UnityEngine;
public class TrnthDeactivateInRunTime : MonoBehaviour {
	void Awake(){
		// Destroy(this);
		gameObject.SetActive(false);
	}
}
