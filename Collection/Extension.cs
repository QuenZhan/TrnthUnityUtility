using System.Collections.Generic;
namespace TRNTH.ContainerExtention
{
    static class Extension{
		public static void ForEachNonAlloc<T>(this IReadOnlyNonAllocList<T> list,IIterator<T> iterator){
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				iterator.Each(i,list[i]);
			}
		}
		public static int Sum<T>(this IReadOnlyNonAllocList<T> list,T value){
			var sum=0;
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				if(list[i].Equals(value))sum++;
			}
			return sum;
		}
        public static void ForEach<T>(this IReadOnlyNonAllocList<T> list,IIterator<T> iterator){
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				iterator.Each(i,list[i]);
			}
		}
		static public void AddRangeNonAlloc<T>(this ICollection<T> list,IReadOnlyNonAllocList<T> other){
			var length=other.Count;
			for (int i = 0; i < length; i++)
			{
				list.Add(other[i]);
			}
		}
		// }
		/// Replace one Null of this list , and return it's index. 
		/// return -1 if there's no any Null in this list 
		static public int ReplaceOneNull<T>(this INonAllocList<T> list,T item) where T:class{
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				if(list[i]!=null)continue;
				list[i]=item;
				return i;
			}
			return -1;
		}
		static public bool HasIntersection<T>(this IReadOnlyNonAllocList<T> a,IReadOnlyNonAllocList<T> b){
			var lengtha=a.Count;
			var lengthb=b.Count;
			for (int ia = 0; ia < lengtha; ia++)
			{
				for (int ib = 0; ib < lengthb; ib++)
				{
					if(a[ia].Equals(b[ib]))return true;
				}
			}
			return false;
		}
		static public bool Contains<T>(this IReadOnlyNonAllocList<T> list,T item){
			if(list==null)return false;
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				if(list[i].Equals(item))return true;
			}
			return false;
		}
		static public void Clear<T>(this INonAllocList<T> list){
			if(list==null)return;
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				list[i]=default(T);
			}
		}
		static public int CopyTo<T>(this IReadOnlyNonAllocList<T> from,INonAllocList<T> to){
			if(from==null)return -1;
			var length=from.Count;
			if(to.Count<length)length=to.Count;
			for (int i = 0; i < length; i++)
			{
				to[i]=from[i];
			}
			return length;
		}
	}
}