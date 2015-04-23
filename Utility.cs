using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace TRNTH{
public class U:Utility{}
public class Utility{
	public static void cleanChildren(Transform tra){
		foreach(var e in tra.Cast<Transform>().ToArray()){
			if(Application.isPlaying){
				UnityEngine.Object.Destroy(e.gameObject);
			}else{
				UnityEngine.Object.DestroyImmediate(e.gameObject);
			}
		}
	}
	public static T ParseEnum<T>( string value ){
	    return (T) System.Enum.Parse( typeof( T ), value, true );
	}
	static public string stringWithNumber(int number,int digit){
		return "";
	}
	static public T[] filter<T>(Component[] arr)where T:Component{
		var list=new List<T>();
		foreach(Component e in arr){
			T c=e.GetComponent<T>();
			if(c)list.Add(c);
		}
		return list.ToArray();
	}
	static public Vector3 dVecY(Vector3 a,Vector3 b){
		return Vector3.Scale(a-b,new Vector3(1,0,1));
	}
	static public string time2String(float time){
		int hh=(int)(Time.realtimeSinceStartup/60/60)%24;
		int mm=(int)(Time.realtimeSinceStartup/60)%60;
		int ss=(int)(Time.realtimeSinceStartup%60);
		return hh+":"+mm+":"+ss;
	}
	static public Vector3 rotateVec(Vector3 vec,Vector3 nor,float theta){
		Vector3 pro=Vector3.Project(vec,nor);
		Vector3 pa=vec-pro;
		return pro+Mathf.Cos(theta)*pa+Vector3.Cross(vec,nor).normalized*Mathf.Sin(theta)*pa.magnitude;
	}
	static public T[] shuffle<T>(T[] arrOrin){
		if(arrOrin.Length<1)return new T[0];
		List<T> list=new List<T>(arrOrin);
		var rng = new System.Random();  
	    int n = list.Count;
	    while (n > 1) {
	        n--;  
	        int k = rng.Next(n + 1);  
	        T value = list[k];  
	        list[k] = list[n];  
	        list[n] = value;  
	    } 
	   	return list.ToArray();
	}
	static public T choose<T>(IList<T> arr){
		if(arr==null||arr.Count<1)return default (T);
		return (T)arr[Random.Range(0,arr.Count)];
	}
	static string getNumString(int num){
		string tagLevel="";
		switch(num){
		case 0:tagLevel="　";break;
		case 1:tagLevel="１";break;
		case 2:tagLevel="２";break;
		case 3:tagLevel="三";break;
		case 4:tagLevel="４";break;
		case 5:tagLevel="５";break;
		case 6:tagLevel="６";break;
		case 7:tagLevel="７";break;
		case 8:tagLevel="８";break;
		case 9:tagLevel="９";break;
		case 10:tagLevel="Ａ";break;
		case 11:tagLevel="Ｂ";break;
		case 12:tagLevel="Ｃ";break;
		case 13:tagLevel="Ｄ";break;
		case 14:tagLevel="Ｅ";break;
		case 15:tagLevel="Ｆ";break;
		case 16:tagLevel="Ｇ";break;
		case 17:tagLevel="Ｈ";break;
		case 18:tagLevel="Ｉ";break;
		case 19:tagLevel="Ｊ";break;
		case 20:tagLevel="Ｋ";break;
		default:tagLevel="超";break;
		}
		return tagLevel;
	}
}
}