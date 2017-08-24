using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour {
	public TheTarget target;
	public void OnTriggerStay2D(Collider2D collier){
		target.Hurt();
	}
}
