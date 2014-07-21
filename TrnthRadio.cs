using UnityEngine;
[System.Serializable]
public class TrnthRadio:MonoBehaviour{
	public float length=100;
	public float rate=1f;
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
	public int value{
		get{
			return (int)(rate*length);
		}set{
			rate=value*1f/length;
		}
	}
	public void clamp(){
		if(rate<0)rate=0;
		if(rate>1)rate=1;
	}
	public string stringPercent(){
		return (int)(rate*100)+"%";
	}
}