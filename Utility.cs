using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TRNTH.Pooling;
// using System.Diagnostics;

namespace TRNTH{
	[System.Flags]
	public enum TileContext{
		None
		,NumPad1=1
			,NumPad2=1<<2
			,NumPad3=1<<3
			,NumPad4=1<<4
			,NumPad6=1<<6
			,NumPad7=1<<7
			,NumPad8=1<<8
			,NumPad9=1<<9
			,North=NumPad8
			,East=NumPad6
			,West=NumPad4
			,South=NumPad2
	}
	public interface IListCell{
		int Index{get;set;}
	}
	public interface ICellSelect{
		void Select(IListCell cell);
	}
	public interface IUIContainer<TData,TCell>{
		IReadOnlyList<TData> Datas{get;}
		void UpdateCell(int index,TData data,TCell cell);
		IReadOnlyList<TCell> Cells{get;}
	}
	public interface IUIContainer<TCell>{
		Transform Parent{get;}
		// TCell Prefab{get;}
		// int Count{get;}
		void UpdateCell(TCell cell);
		void Init(TCell cell);
	}
	public class U:Utility{}
	public class Utility{
		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void GetAllAssets<T>(IList<T> toHere) where T:class{
			#if UNITY_EDITOR
			var type=typeof(T);
			var guids= UnityEditor.AssetDatabase.FindAssets(string.Format("t:{0}",type.Name));
			toHere.Clear();
			foreach(var guid in guids){
				var path=UnityEditor.AssetDatabase.GUIDToAssetPath (guid);
				var recipe=UnityEditor.AssetDatabase.LoadAssetAtPath(path,type) as T;
				toHere.Add(recipe);
			}
			#endif
		}
		static public void CheckSerializingType<T>(ref T member,ref MonoBehaviour monoScript) where T:class{
			#if UNITY_EDITOR
			 if(monoScript!=null){
				member=monoScript as T;
                if(member==null){
					monoScript=null;
					Debug.LogErrorFormat("monoScript is not {1}",typeof(T).Name);
				}
            }
			#endif
		}
		static public bool AutoFinding<T,T2>(bool _autoFinding,IList<T2> monoArray,Transform root) where T:class where T2:MonoBehaviour{
			if(!_autoFinding)return false;
			monoArray.Clear();
			foreach (var item in root.GetComponentsInChildren<T2>())
			{
				if(item is T){
					monoArray.Add(item);
				}
			}
			return false;
		}
		static public bool RepeatCounterUpdate(ref float counter,float duration,float deltaSconds){
			 counter-=deltaSconds;
            if(counter<=0){
                counter=duration;
				return true;
			}
			return false;
		}
		static public void WorldToLocalScaledAnchoredPosition(Vector3 worldposition,Camera camera,RectTransform target){
			var screenPoint=camera.WorldToScreenPoint(worldposition);
			var rect=(target.parent as RectTransform).rect;
			target.anchorMax=Vector2.zero;
			target.anchorMin=Vector2.zero;
			target.anchoredPosition=new Vector2(screenPoint.x/Screen.width*rect.width,screenPoint.y/Screen.height*rect.height);
		}
		public const int WaterLayer=4;
		public readonly ContactFilter2D WaterFilter=new ContactFilter2D(){useLayerMask=true,layerMask=1<<WaterLayer,useTriggers=true};
		public static string IntToStringNonAllocUnder1000(float number){
					return IntToStringNonAllocUnder1000((int)number);
				}
		public static string IntToStringNonAllocUnder1000(double number){
			return IntToStringNonAllocUnder1000((int)number);
		}
		public static string IntToStringNonAllocUnder1000(byte number){
			return IntToStringNonAllocUnder1000((int)number);
		}
		public static string IntToStringNonAllocUnder1000(int number){
			var limit=1000;
			if(StringNumber==null){
				StringNumber=new string[limit];
				for(var i=0;i<limit;i++){
					StringNumber[i]=i.ToString();
				}
			}
			if(number<0 || number>=limit)return OutOfRange;
			return StringNumber[number];
		}
		static public void PreSpawn<T>(Transform parent,IList<T> _Instances){
			_Instances.Clear();
			var length=parent.childCount;
			for (int i = 0; i < length; i++)
			{
				var ins=parent.GetChild(i).GetComponent<T>();
				if(ins==null)continue;
				_Instances.Add(ins);
			}
		}
		static string[] StringNumber; 
		const string OutOfRange="--";
		static public Ray MousePositionRay(Camera c){
			Vector2 mousePos = new Vector2();
			mousePos.x = Input.mousePosition.x;
			mousePos.y = Input.mousePosition.y;
			var worldPosition=c.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,c.nearClipPlane));
			var ray=new Ray(worldPosition,c.transform.TransformDirection(Vector3.forward));
			return ray;
		}
		static public Vector2 MousePositionToAnchoredPosition(RectTransform parent){
			var rect=parent.rect;
			return new Vector2(Input.mousePosition.x/Screen.width*rect.width,Input.mousePosition.y/Screen.height*rect.height);
		}
		public static void UIContainerRefresh<TData,TCell>(IUIContainer<TData,TCell> container){
			var datas=container.Datas;
			var size=datas.Count;
			size=container.Cells.Count;
			for(var i=0;i<size;i++){
				var cell=container.Cells[i];
				if(i>=datas.Count)container.UpdateCell(i,default(TData),cell);
				else container.UpdateCell(i,datas[i],cell);
			}
		}
		const string CellNameFormat="{0}:{1}";
		public static void IsolateInSiblings(Transform tra){			
			var parent=tra.parent;
			if(parent==null){
				Debug.LogWarning ("dont isolate a root gameObject",tra);
				return ;
			}
			foreach(Transform e in parent){
				e.gameObject.SetActive(e==tra);
			}
		}
		public static void DespawnChildren<T>(Transform parent) where T:Component{
			var children=parent.GetComponentsInChildren<T>(true);
			foreach(var e in children){
//				if(Pool.Despawn(e.gameObject))continue;
				e.gameObject.SetActive(false);
			}
		}
		static readonly List<Transform> _children=new List<Transform>();
		public static void cleanChildren(Transform tra){
			if(tra==null)return;
			var length=tra.childCount;
			// Debug.LogFormat("tra.childCount:{0}",length);
			_children.Clear();
			for (int i = 0; i < length; i++)
			{
				var child=tra.GetChild(i);
				_children.Add(tra.GetChild(i));
			}
			length=_children.Count;
			for (int i = 0; i < length; i++)
			{
				var child=_children[i];
				if(Application.isPlaying){
					UnityEngine.Object.Destroy(child.gameObject);
				}else{
					UnityEngine.Object.DestroyImmediate(child.gameObject);
				}
				
			}
			// foreach(var e in tra.Cast<Transform>().ToArray()){
			// 	if(Application.isPlaying){
			// 		UnityEngine.Object.Destroy(e.gameObject);
			// 	}else{
			// 		UnityEngine.Object.DestroyImmediate(e.gameObject);
			// 	}
			// }
		}	
		public static void RestTransform(Transform tra){
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
			try{
				return (T) System.Enum.Parse( typeof( T ), value, true );				
			}
			catch{
				return default(T);
			}
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
		static public Transform chooseChild(Transform tra){
			if(tra==null){
				Debug.Log("tra==null");
				return tra;
			}
			var list=new List<Transform>(){tra};
			foreach(Transform e in tra){
				list.Add(e);
			}
			if(list.Count==0)list.Add(tra);
			return choose<Transform>(list.ToArray());
		}
		static public T choose<T>(IList<T> arr){
			if(arr==null||arr.Count<1)return default (T);
			return (T)arr[Random.Range(0,arr.Count)];
		}
		static public T choose<T>(params T[] arr){
			if(arr.Length<1)return default (T);
			return arr[Random.Range(0,arr.Length)];
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