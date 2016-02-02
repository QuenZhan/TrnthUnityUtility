using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var routine=_r();
		StartCoroutine(routine);
		StartCoroutine(_Stoper(routine));
	}
	IEnumerator _r(){
		yield return new WaitForSeconds(1);
		Debug.Log(1,this);
		yield return new WaitForSeconds(1);
		Debug.Log(2,this);
		yield return new WaitForSeconds(1);
		Debug.Log(3,this);
		yield return new WaitForSeconds(1);
		Debug.Log(4,this);
	}
	IEnumerator _Stoper(IEnumerator routine){
		yield return new WaitForSeconds(2);
		Debug.Log("Stop it");
		StopCoroutine(routine);
	}
	void Update () {
	
	}
}
