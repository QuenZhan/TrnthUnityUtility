using UnityEngine;
using System.Collections;

[System.Serializable]
public class TrnthRadioData : ITrnthRadio,ITrnthRadioGet {
	public float rate{
		get{return (length==0)?0:value/length;}
		set{
			if(this.value!=value){
				this.value=value*length;
				onChange(this);
				return;
			}
			this.value=value*length;
		}
	}
	public float value{
		get{return _value;}
		set{
			if(_value!=value){
				_value=value;
				onChange(this);
			}
			_value=value;
		}
	}
	public float length{
		get{return _length;}
		set{
			if(_length!=value){
				_length=value;
				onChange(this);
			}
			_length=value;
		}
	}
	public void clamp(){
		if(value>length)value=length;
		if(value<0)value=0;
	}
	public event System.Action<ITrnthRadio> onChange=delegate{};
	[SerializeField]float _value;
	[SerializeField]float _length;
}
