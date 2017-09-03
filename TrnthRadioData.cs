using UnityEngine;
using System.Collections;

[System.Serializable]
public class TrnthRadioData : ITrnthRadio,IReadonlyTrnthRadio {
	public float rate{
		get{return (length==0)?0:((_value - _min)/length);}
		set{
			if(rate!=value){
				_value=Mathf.Lerp(_min,_max,value);
				onChange(this);
				return;
			}
			_value=Mathf.Lerp(_min,_max,value);
		}
	}
	public float value{
		get{return _value;}
		set{
			if(_value!=value){
				_value=value;
				onChange(this);
				return;
			}
			_value=value;
		}
	}
	public float length{
		get{return _max	- _min;}
		set{
			// if(length!=value){
				// onChange(this);
			// }
			_max=value + _min;
		}
	}
	public virtual void clamp(){
		if(_value>_max){
			_value=_max;
			onChange(this);
		}
		if(_value<_min){
			_value=_min;
			onChange(this);
		}
	}
	public float min{get{return _min;}set{_min=value;}}
	public float max{get{return _max;}set{_max=value;}}
	public event System.Action<ITrnthRadio> onChange=delegate{};
	[SerializeField]float _value=100;
	[SerializeField]float _min=0;
	[SerializeField]float _max=100;
}
