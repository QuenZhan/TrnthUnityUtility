using UnityEngine;
[System.Serializable]
public class TrnthRadio:MonoBehaviour,ITrnthRadioGet{
	[SerializeField]float _length=100;
	// [SerializeField]float _rate=1;
	public float length{get{return _length;}set{_length=value;onChanged(this);}}
	public float rate{
		get{
			return _value/_length;
		}set{
			_value=value*_length;
			onChanged(this);
		}
	}
	public bool fullOnEnable=true;
	// public GameObject onEdge;
	public static TrnthRadio operator +(TrnthRadio a,float b){
		a.rate+=b/a.length;
		return a;
	}		
	public static TrnthRadio operator -(TrnthRadio a,float b){
		return a+b*-1;
	}
	public bool toggle{
		set{
			if(value)rate=1f;
			else rate=0f;
			onChanged(this);
		}
	}
	public float value{
		get{
			return _value;
		}set{
			_value=value;
			onChanged(this);
		}
	}
	public void clamp(){
		if(rate<0)rate=0;
		if(rate>1)rate=1;
		onChanged(this);
	}
	public string stringPercent(){
		return (int)(rate*100)+"%";
	}
	public event System.Action<TrnthRadio> onChanged=delegate{};
	float _value;
	void OnEnable(){
		if(fullOnEnable)toggle=true;
	}
}