using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.UI{

	public class UIClamper : MonoBehaviour {
		public Transform WorldPositionTarget;
		[SerializeField]Camera _camera;
		[SerializeField]Transform _topRight;
		[SerializeField]Transform _botLeft;
		public void Execute()
		{
			if(!_thisRect)_thisRect=GetComponent<RectTransform>();
			U.WorldToLocalScaledAnchoredPosition(WorldPositionTarget.position,_camera,_thisRect);
			_thisRect.Clamp(_topRight.localPosition,_botLeft.localPosition);			

		}
		private void LateUpdate() {
			Execute();
		}
		RectTransform _thisRect;
		// Use this for initialization
		void Start () {
			if(!_thisRect)_thisRect=GetComponent<RectTransform>();
		}
		
	}
}

