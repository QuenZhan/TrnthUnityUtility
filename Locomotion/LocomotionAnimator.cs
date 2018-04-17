using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public class LocomotionAnimator : MonoBehaviour {
		[SerializeField]Animator _animator;
		[SerializeField]public string AnimatorParameterSpeed="Speed";
		[SerializeField]Locomotion _locomotion;
		public void UpdateWith(float value){
		}
		void Update () {
			var delta=_locomotion.Velocity;
			_animator.SetFloat(AnimatorParameterSpeed,delta.sqrMagnitude);
		}
	}

}
