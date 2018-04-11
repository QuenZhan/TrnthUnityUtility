using UnityEngine;
namespace TRNTH
{
    public sealed class LocomotionPosition:Locomotion{
		public override void UpdateWith(float deltaSeconds){
			var newcurrent=Vector3.MoveTowards(_myTransform.localPosition,Target,maxDistanceDelta);
			var delta=newcurrent-_myTransform.localPosition;
			_myTransform.localPosition=newcurrent;
			_animator.SetFloat(AnimatorParameterSpeed,delta.sqrMagnitude/deltaSeconds);
		}
	}
}
