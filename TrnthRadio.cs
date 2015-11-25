using UnityEngine;
[System.Serializable]
public class TrnthRadio:MonoBehaviour,ITrnthRadioGet,ITrnthRadio{
	[SerializeField]float _value=100;
	[SerializeField]float _min=0;
	[SerializeField]float _max=100;
	public float length{get{return _max - _min;}set{_max=_min+value;onChange(this);}}
	public float rate{
		get{
			return (_value - _min) /length;
		}set{
			_value=Mathf.Lerp(_min,_max,value);
			onChange(this);
		}
	}
	public bool fullOnEnable=true;
	public bool toggle{
		set{
			if(value)rate=1f;
			else rate=0f;
			onChange(this);
		}
	}
	public float value{get{return _value;}set{_value=value;onChange(this);}}
	public float min{get{return _min;}set{_min=value;onChange(this);}}
	public float max{get{return _max;}set{_max=value;onChange(this);}}
	public void clamp(){
		if(rate<0)rate=0;
		if(rate>1)rate=1;
		onChange(this);
	}
	public string stringPercent(){
		return (int)(rate*100)+"%";
	}
	public event System.Action<ITrnthRadio> onChange=delegate{};
	void OnEnable(){
		if(fullOnEnable)toggle=true;
	}
}