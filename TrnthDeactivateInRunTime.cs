using UnityEngine;
public class TrnthDeactivateInRunTime : MonoBehaviour {
	void Awake(){
		// Destroy(this.gameObject);
		gameObject.SetActive(false);
	}
}
