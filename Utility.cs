using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace TRNTH{
public class U:Utility{}
public class Utility{
	public static void cleanChildren(Transform tra){
		if(tra==null)return;
		foreach(var e in tra.Cast<Transform>().ToArray()){
			if(Application.isPlaying){
				UnityEngine.Object.Destroy(e.gameObject);
			}else{
				UnityEngine.Object.DestroyImmediate(e.gameObject);
			}
		}
	}
	public static void transformRest(Transform tra){
		tra.localPosition=Vector3.zero;
		tra.localScale=Vector3.one;
		tra.localEulerAngles=Vector3.zero;
	}
	public static T first<T>(IList<T> list){
		if(list.Count<1)return default(T);
		return list[0];
	}
	public static T last<T>(IList<T> list){
		if(list.Count<1)return default(T);
		return list[list.Count-1];
	}
	public static T ParseEnum<T>( string value ){
		var names=new List<string>(System.Enum.GetNames(typeof(T)));
		if(!names.Contains(value)){
			Debug.LogWarning(string.Format("ParseEnum<T> !names.Contains(value) {0} {1}",value,typeof(T).Name));
			return default(T);
		}
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
	static public string t2s(float time){
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
	static public T[] shuffle<T>(T[] arrOrin) {
		if(arrOrin.Length<1)return arrOrin;
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
	static public Object[] shuffle(Object[] arrOrin){
		return shuffle<Object>(arrOrin);
	}
	static public Transform chooseChild(Transform tra){
		if(tra==null){
			Debug.Log("tra==null");
			return tra;
		}
		var list=new List<Transform>();
		// list.Add(tra);
		foreach(Transform e in tra){
			list.Add(e);
		}
		return choose<Transform>(list.ToArray());
	}
	static public T choose<T>(IList<T> arr){
		if(arr==null||arr.Count<1)return default (T);
		return (T)arr[Random.Range(0,arr.Count)];
	}
	// static public T choose<T>(Object[] arr)where T:Object{
	// 	if(arr.Length<1)return null;
	// 	return arr[Random.Range(0,arr.Length)] as T;
	// }
	static public T choose<T>(params T[] arr){
		if(arr.Length<1)return default (T);
		return arr[Random.Range(0,arr.Length)];
	}
	static public string choose(string[] arr){
		if(arr.Length<1)return "";
		return arr[Random.Range(0,arr.Length)];
	}
	static public Vector3 choose(Vector3[] arr){
		if(arr.Length<1)return Vector3.zero;
		return arr[Random.Range(0,arr.Length)];
	}
	static public System.Object choose(System.Object[] arr){
		if(arr.Length<1)return null;
		return arr[Random.Range(0,arr.Length)];
	}
	static public Object choose(Object[] arr){
		if(arr.Length<1)return null;
		return arr[Random.Range(0,arr.Length)];
	}
	static public GameObject choose(List<GameObject> list){
		return choose(list.ToArray());
	}
	static public Transform choose(Transform gos){
		return chooseChild(gos);
	}
	static public GameObject choose(GameObject[] gos){
		if(gos.Length<1)return null;
		return gos[Random.Range(0,gos.Length)];
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