using System.Collections.Generic;
namespace TRNTH.ContainerExtention
{
    static class Extension{
		public static void GetPage<T>(this IReadOnlyNonAllocList<T> list
		,List<T> toHere
		,int page
		,int itemsPerPage
		){
			toHere.Clear();
			for (int i = page*itemsPerPage; i < (page+1)*itemsPerPage; i++)
			{
				if(i>=list.Count)return;
				toHere.Add(list[i]);
			}
		} 
		public static int NullCount<T>(this IReadOnlyNonAllocList<T> list) where T:class{
			int count=0;
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				if(list[i]==null)count++;
			}
			return count;
		}

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
		static public int IndexOf<T>(this IReadOnlyNonAllocList<T> list,T item){
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				if(list[i].Equals(item))return i;
			}
			return -1;
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
		static public void DefaultAll<T>(this INonAllocList<T> list){
			if(list==null)return;
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				list[i]=default(T);
			}
		}
		static public void CopyTo<T>(this IReadOnlyNonAllocList<T> from,T[] to){
			if(to.Length<from.Count)throw new System.InvalidOperationException(string.Format("to.Length:{0}<from.Count:{0}",to.Length,from.Count));
			var length=from.Count;
			for (int i = 0; i < length; i++)
			{
				to[i]=from[i];
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