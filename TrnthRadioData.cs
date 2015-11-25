using UnityEngine;
using System.Collections;

[System.Serializable]
public class TrnthRadioData : ITrnthRadio,ITrnthRadioGet {
	public float rate{
		get{return (length==0)?0:(_value - _min)/length;}
		set{
			if(_value!=value){
				onChange(this);
			}
			_value=Mathf.Lerp(_min,_max,value);
		}
	}
	public float value{
		get{return _value;}
		set{
			if(_value!=value){
				onChange(this);
				// return;
			}
			_value=value;
		}
	}
	public float length{
		get{return _max	- _min;}
		set{
			if(length!=value){
				onChange(this);
			}
			_max=value + _min;
		}
	}
	public void clamp(){
		if(rate>1)rate=1;
		if(rate<0)rate=0;
	}
	public float min{get{return _min;}set{_min=value;onChange(this);}}
	public float max{get{return _max;}set{_max=value;onChange(this);}}
	public event System.Action<ITrnthRadio> onChange=delegate{};
	[SerializeField]float _value=100;
	[SerializeField]float _min=0;
	[SerializeField]float _max=100;
}
