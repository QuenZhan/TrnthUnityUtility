using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public class CameraController : MonoBehaviour {
		static public CameraController Instance{get;private set;}
		public Transform Followee;
		public Vector3 Postion;
		Vector3 vel;
		public void Start(){
			Instance=this;
		}
		public virtual void Update(){
			if(Followee!=null)Postion=Followee.position;
			transform.position=Vector3.SmoothDamp(transform.position,Postion,ref vel,0.2f);
		}
	}
}