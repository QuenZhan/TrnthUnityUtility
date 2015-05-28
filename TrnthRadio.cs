using UnityEngine;
[System.Serializable]
public class TrnthRadio:MonoBehaviour,ITrnthRadioGet{
	[SerializeField]float _length=100;
	// [SerializeField]float _rate=1;
	public float length{get{return _length;}set{_length=value;}}
	public float rate{
		get{
			return _value/_length;
		}set{
			_value=value*_length;
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
		}
	}
	public float value{
		get{
			return _value;
		}set{
			_value=value;
		}
	}
	public void clamp(){
		if(rate<0)rate=0;
		if(rate>1)rate=1;
	}
	public string stringPercent(){
		return (int)(rate*100)+"%";
	}
	float _value;
	void OnEnable(){
		if(fullOnEnable)toggle=true;
	}
}