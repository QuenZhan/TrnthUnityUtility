using UnityEngine;
namespace TRNTH
{
    public abstract class Locomotion:MonoBehaviour{
		public Vector3 Target;
		[SerializeField]protected Transform _myTransform;
		[SerializeField]public float maxDistanceDelta=0.5f;
		public Vector3 Position{get{return _myTransform.localPosition;}}
		// [SerializeField]protected Animator _animator;
		// [SerializeField]public string AnimatorParameterSpeed="Speed";
		private void Start() {
			_myTransform.SetParent(null);
		}
		public abstract Vector3 Velocity{get;}
		public abstract void UpdateWith(float deltaSeconds);
	}
}
