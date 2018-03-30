using UnityEngine;
using UnityEngine.UI;

namespace TRNTH.UI
{
    public class SimpleSlider:MonoBehaviour{
		[SerializeField] RectTransform _Parent;
		[SerializeField] RectTransform _Fill;
		[SerializeField]Image _image;
		[SerializeField]float _min=0;
		[SerializeField]float _Max=1;
		[SerializeField]Text _percentage;
		[SerializeField]Color _textColorLower;
		[SerializeField]Color _textColorHigher;
		public void Refresh(float zeroToOne){
			if(_image){
				_image.fillAmount=Mathf.Lerp(_min,_Max,zeroToOne);
				return;
			}
			var size=_Parent.sizeDelta;
			size.x*=zeroToOne;
			_Fill.sizeDelta=size;
			if(_percentage){
				_percentage.text=U.IntToStringNonAllocUnder1000(zeroToOne*100);
				if(zeroToOne>0.5f)_percentage.color=_textColorHigher;
				else _percentage.color=_textColorLower;
			}
		}
		public bool Showing{
			get{
				return _Parent.gameObject.activeSelf;
			}
			set{
				_Parent.gameObject.SetActive(value);
			}
		}
	}
}
