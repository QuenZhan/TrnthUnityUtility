using UnityEngine;
namespace TRNTH
{
    public sealed class LocomotionCharacterController:Locomotion{
		[SerializeField]CharacterController _ccr;

        public override void UpdateWith(float deltaSeconds)
        {
			var newTarget=Vector3.MoveTowards(_myTransform.localPosition,Target,maxDistanceDelta);
            _ccr.Move(newTarget-_myTransform.localPosition);
			_animator.SetFloat(AnimatorParameterSpeed,_ccr.velocity.sqrMagnitude);
        }
    }
}
