using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public class CameraController : TrnthMonoBehaviour {
		static public CameraController Instance{get;private set;}
		public Transform Followee;
		public Vector3 TargetLocalposition;
		public float Threshold;
		Vector3 vel;
		public virtual void Start(){
			Instance=this;
		}
		public virtual void Update(){
			if(Followee!=null){
				var detla=Followee.localPosition-TargetLocalposition;
				var overThreshod=Mathf.Abs(detla.x)>Threshold || Mathf.Abs(detla.z)>Threshold;
				// var distanceDelta=detla.sqrMagnitude-Threshold*Threshold;
				if(overThreshod){
					TargetLocalposition+=Vector3.ClampMagnitude(detla,1);
				}
			}
		}
		[SerializeField]float maxSpeed=5;
		private void LateUpdate() {			
			tra.localPosition=Vector3.SmoothDamp(tra.localPosition,TargetLocalposition,ref vel,0.1f,maxSpeed);
			// tra.localPosition=Vector3.Lerp(tra.localPosition,TargetLocalposition,0.2f);
		}
	}
}