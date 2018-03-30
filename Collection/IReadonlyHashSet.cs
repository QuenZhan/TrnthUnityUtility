using System.Collections;
using System.Collections.Generic;

namespace TRNTH
{
    public interface IReadonlyHashSet<T>  {
		bool Contains(T item);
		int Count{get;}
	}
    public interface IReadOnlyNonAllocList<T>{
		T this[int index]{get;}
		int Count{get;}
	}
	public interface INonAllocList<T>:IReadOnlyNonAllocList<T>{
		new T this[int index]{get;set;}
	}
	[System.Serializable]public class MutableNonAllocList<T>:INonAllocList<T>{
		[UnityEngine.SerializeField]List<T> _list=new List<T>(10);
		public MutableNonAllocList(int max=10){
			this.Max=max;
			_list=new List<T>(max);
		}
		public int Max=10;

        public T this[int index] { 
			get {
				return _list[index];
			}
			set{
				_list[index]=value;
			}
		}

        public int Count{get{return _list.Count;}}

        public void Add(T item)
        {
			if(_list.Count>=Max)throw new System.InvalidOperationException(string.Format("_list.Count>=Max:{0}",_list.Count));
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public void Remove(T item)
        {
            _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
    }
}
namespace TRNTH.ContainerExtention
{
}