using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrnthUIClickOff : MonoBehaviour {
	void Start () {
		GetComponent<Button>().onClick.AddListener(()=>{gameObject.SetActive(false);});
	}
}
