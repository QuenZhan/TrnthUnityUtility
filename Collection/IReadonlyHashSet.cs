using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public interface IReadonlyHashSet<T>  {
		bool Contains(T item);
		int Count{get;}
	}
	public class HashSet<T>:System.Collections.Generic.HashSet<T>,IReadonlyHashSet<T>{

	}
	public interface IReadOnlyNonAllocList<T>{
		T this[int index]{get;}
		int Count{get;}
	}
	public interface INonAllocList<T>:IReadOnlyNonAllocList<T>{
		new T this[int index]{get;set;}
	}
    public class NonAllocList<T> : INonAllocList<T>
    {
		[SerializeField]T[] _datas;
		public NonAllocList():this(0){

		}
		public NonAllocList(int size){
			_datas=new T[size];
		}
        public T this[int index]
        {
            get
            {
                return _datas[index];
            }

            set
            {
                _datas[index]=value;
            }
        }
        public int Count {get{return _datas.Length;}}
    }
}
namespace TRNTH.ContainerExtention{
	static class Extension{
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
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				list[i]=default(T);
			}
		}
		static public int CopyTo<T>(this IReadOnlyNonAllocList<T> from,INonAllocList<T> to){
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