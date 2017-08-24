using UnityEngine;
using System.Collections;

public class TrnthAnimatorProxy : MonoBehaviour {
	public Animator animator;
	public delegate void Callback();
	public event Callback callback;
	public void exectureEvent(){
		if(callback!=null)callback();
	}
}
