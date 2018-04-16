using UnityEngine;
namespace TRNTH
{
    public sealed class LocomotionPosition:Locomotion{
        public override Vector3 Velocity
        {
            get{
				return _delta;
			}
        }
		Vector3 _delta;

        public override void UpdateWith(float deltaSeconds){
			var newcurrent=Vector3.MoveTowards(_myTransform.localPosition,Target,maxDistanceDelta);
			_delta=(newcurrent-_myTransform.localPosition)/deltaSeconds;
			_myTransform.localPosition=newcurrent;
			// _animator.SetFloat(AnimatorParameterSpeed,delta.sqrMagnitude/deltaSeconds);
		}
	}
}
