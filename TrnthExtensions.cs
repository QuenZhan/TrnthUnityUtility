using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using System;

namespace TRNTH{
	public static class TrnthExtensions
	{
		public static void ToggleAll<T>(this IList<T> list,bool toggle) where T:Component{
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				list[i].gameObject.SetActive(toggle);
			}
		}
		public static void Freeze(this Transform tra){
			tra.localPosition=Vector3.zero;
			tra.localRotation=Quaternion.identity;
			tra.localScale=Vector3.one;
		}
		public static void DestoryAll<T>(this IList<T> list) where T:UnityEngine.Object{
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				if(Application.isPlaying)GameObject.Destroy(list[i]);
				else GameObject.DestroyImmediate(list[i]);
			}

		}
		
		public static void ForEachNonAlloc<T>(this IList<T> list,IIterator<T> iterator){
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				iterator.Each(i,list[i]);
			}
		}
		public static void DestroyAllChildren(this Transform transform){
			U.cleanChildren(transform);
		}
		public static Vector2 Clamp(this Vector2 vec
		,Vector2 smallTopRight
		,Vector2 smallBottomLeft
		,Vector2 TopRight
		,Vector2 BottomLeft
		){
			var _position=vec;
			var leftBorderWidth=vec.x-smallBottomLeft.x;
			var rightBorder=smallTopRight.x-vec.x;
			var topBorder=smallTopRight.y-vec.y;
			var bottomBorer=vec.y-smallTopRight.y;
			var left=BottomLeft.x+leftBorderWidth;
			var right=TopRight.x-rightBorder;
			var top=TopRight.y-topBorder;
			var bot=BottomLeft.y+bottomBorer;
			if(_position.x<left)_position.x=left;
			if(_position.x>right)_position.x=right;
			if(_position.y>top)_position.y=top;
			if(_position.y<bot)_position.y=bot;
			return _position;
		}
		
		static public void Clear<T>(this T[] array){
			var length=array.Length;
			System.Array.Clear(array,0,length);
		}
		static public void RemoveAllNullNonAlloc<T>(this IList<T> list,IList<T> tmpList){
			tmpList.Clear();
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				if(list[i]==null)continue;
				tmpList.Add(list[i]);
			}
			list.Clear();
			length=tmpList.Count;
			for (int i = 0; i < length; i++)
			{
				list.Add(tmpList[i]);
			}
		}

		static public void ResetOnClick(this Button button,UnityEngine.Events.UnityAction onClick){
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(onClick);
		}
		// static public void AddRangeNonAlloc<T>(this HashSet<T> list,IReadOnlyList<T> toAdd){
		// 	var length=toAdd.Count;
		// 	for (int i = 0; i < length; i++)
		// 	{
		// 		list.Add(toAdd[i]);
		// 	}
		// }
		static public void AddRangeNonAlloc<T>(this ICollection<T> list,INonAllocList<T> toAdd){
			var length=toAdd.Count;
			for (int i = 0; i < length; i++)
			{
				list.Add(toAdd[i]);
			}
		}
		public static void GetPage<T>(this IList<T> list,List<T> toHere,int page,int itemsPerPage){
			toHere.Clear();
			for (int i = page*itemsPerPage; i < (page+1)*itemsPerPage; i++)
			{
				if(i>=list.Count)return;
				toHere.Add(list[i]);
			}
		}
		public static IEnumerable<T> Page<T>(this IEnumerable<T> list,int page,int sizePerPage){
			var startIndex=page*sizePerPage;
			if(list.Count() >=startIndex){
				list=list.GetRange(startIndex,Mathf.Min(sizePerPage,list.Count()-startIndex));
			}
			return list;
		}
		public static IEnumerable<T> Intersection<T>(this IEnumerable<T> a,IEnumerable<T> b) {
			return a.FindAll(t=>{
				bool yes=false;
				foreach(var tt in b){
					if(tt is System.IEquatable<T>){
						var camparer=(System.IEquatable<T>)tt;
						yes=camparer.Equals(t);
						if(yes)return yes;
					}
					yes= tt.Equals(t);
					if(yes)return yes;
				}
				return false;
			})
			;
		}
		public static IEnumerable<T> GetUniqueFlags<T>(this System.Enum flags) 
		{
			
			ulong flag = 1;
			foreach (var value in System.Enum.GetValues(flags.GetType()).ConvertAll<T>())
			{
				ulong bits = System.Convert.ToUInt64(value);
				while (flag < bits)
				{
					flag <<= 1;
				}
				
				if (flag == bits && (System.Convert.ToUInt64(flags) & System.Convert.ToUInt64(value))!=0)
				{
					yield return value;
				}
			}
		}
		public static IEnumerable<T> GetRange<T>(this  IEnumerable<T> container,int start,int count){
			var list=new List<T>(container);
			if(list.Count<count+start){
				return list;
			}
			return list.GetRange(start,count);
		}
		public static T Find<T>(this IEnumerable<T> list,T value) where T : class
		{
			foreach(T e in list){
				if(value==(e))return e;
			}
			return default(T);
		}
		public static T Find<T>(this IEnumerable<T> collect,System.Predicate<T> predicate){
			return new List<T>(collect).Find(predicate);
		}
		public static IEnumerable<T> FindAll<T>(this IEnumerable<T> collect,System.Predicate<T> predicate){
			return new List<T>(collect).FindAll(predicate);
		}
		public static bool Exists <T>(this IEnumerable<T> collect,System.Predicate<T> predicate){
			return new List<T>(collect).Exists(predicate);
		}
		public static int Count <T>(this IEnumerable<T> collect){
			return new List<T>(collect).Count;
		}
		public static T[] ToArray<T>(this IEnumerable<T> list){
			return new List<T>(list).ToArray();
		}
		public static T FindNearest<T>(this IList<T>componenents,Vector3 position) where T:Component{
			T nearest=null;
			var length=componenents.Count;
			for (int i = 0; i < length; i++)
			{
				var t=componenents[i] as T;
				if(t==null)continue;
				if(nearest==null){
					nearest=t;
					continue;
				}
				var distanceN=nearest.transform.position-position;
				var distanceT=componenents[i].transform.position-position;
				if(distanceT.sqrMagnitude<distanceN.sqrMagnitude)nearest=t;
			}
			return nearest;
		}
		public static T RandomChooseNonAlloc<T>(this IList<T> list){
			if(list.Count<1)return default(T);
			return list[Random.Range(0,list.Count)];
		}
		static readonly System.Random rng=new System.Random();
		public static IList<T> Shuffle<T>(this IList<T> arrOrin){
			var list=arrOrin;
			// var rng = new System.Random();  
			int n = arrOrin.Count;
			while (n > 1) {
				n--;  
				int k = rng.Next(n + 1);  
				T value = list[k];  
				list[k] = list[n];  
				list[n] = value;  
			} 
			return list;
		}
		public static void send(this MonoBehaviour monoBehaviour,TrnthHVSCondition condition){
			if(condition)condition.send();
		}
		public static IList<T> CastComponent<T>(this Component component){
			return component.transform.ConvertAll<Transform>().CastComponent<T>();
		}
		public static IList<T> CastComponent<T>(this IEnumerable components){
			var list=new List<T>();
			foreach(Component e in components){
				var c=e.GetComponent<T>();
				if(c!=null)list.Add(c);
			}
			return list;
		}
		public static IEnumerable<T2> ConvertAll<T,T2>(this IEnumerable<T> container,System.Converter<T,T2> converter){
			return new List<T>(container).ConvertAll<T2>(converter);
		}
		public static IEnumerable<T> ConvertAll<T>(this IEnumerable container){
			var list=new List<T>();
			var e=container.GetEnumerator();
			while(e.MoveNext()){
				if(e.Current is T)list.Add((T)(e.Current));
			}
			return list;
		}
	}
	public interface IIterator<T>{
		void Each(int index,T item);
	}
}