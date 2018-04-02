using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH
{
    [System.Serializable]public class NonAllocList<T> : INonAllocList<T>
    {
        public void Sort(IComparer<T> campareer){
            System.Array.Sort(_datas,campareer);
        }
        #if UNITY_EDITOR
        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public void SetArray(T[] value){
            _datas=value;
        }
        #endif
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
                #if UNITY_EDITOR
                if(index<0 || index>Count)throw new System.IndexOutOfRangeException(string.Format("index:{0},Count:{1}",index,Count));
                #endif
                _datas[index]=value;
            }
        }
        public int Count {get{return _datas.Length;}}
    }
    public interface IReadonlyNonAllocDicionary<TKey,TValue>{
        bool TryGetValue(TKey key,out TValue value);
    }
    public interface INonAllocDicionary<TKey,TValue>:IReadonlyNonAllocDicionary<TKey,TValue>{
        TValue this[TKey key]{set;}
    }
    public interface IKeyedItem<TKey>{
        TKey Key{get;}
        // int Index{get;set;}
    }
}
