using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
	void OnTriggerStay2D(Collider2D other)
	{
		var animator=other.GetComponent<Animator>();
		animator.Play("test2");
	}
}
