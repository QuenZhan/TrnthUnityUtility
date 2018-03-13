using UnityEngine;
namespace TRNTH
{
	public interface IFacer
	{
		bool FaceRight{get;set;}
	}
    [System.Serializable]public class FaceRotator:IFacer{
		[SerializeField]Transform _Rotator;
		public bool FaceRight{
			get{
				return _Rotator.localScale.x>0;
			}
			set{
				_Rotator.localScale=new Vector3(value?1:-1,1,1);
			}
		}
	}
}