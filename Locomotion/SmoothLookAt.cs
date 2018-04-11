using UnityEngine;
namespace TRNTH
{
    public class SmoothLookAt:MonoBehaviour{
		public Vector3 Target;
		[SerializeField]Vector3 _current;
		[SerializeField]Transform _myTransform;
		[SerializeField]float _maxRadiation=0.1f;
		public void UpdateWith(float deltaSeconds){
			_current=Vector3.RotateTowards(_current,Target,_maxRadiation,1);
			_myTransform.LookAt(_current);
		}
	}
}
