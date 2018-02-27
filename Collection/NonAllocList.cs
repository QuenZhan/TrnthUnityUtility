using System.Collections.Generic;
using UnityEngine;
namespace TRNTH
{
    public class NonAllocList<T> : INonAllocList<T>
    {
        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public void SetArray(T[] value){
            _datas=value;
        }
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
    public interface IReadonlyNonAllocDicionary<TKey,TValue>:IReadOnlyNonAllocList<TKey>{
        TValue this[TKey index]{get;}
    }
    public interface INonAllocDicionary<TKey,TValue>:IReadonlyNonAllocDicionary<TKey,TValue>{
        new TValue this[TKey index]{get;set;}
    }
    public abstract class NonAllocFixedSizeDictionary<TKey,TValue>:ISerializationCallbackReceiver
    ,INonAllocDicionary<TKey,TValue>{
		[SerializeField]TKey[] _keys;
        [SerializeField]List<TValue> _values;
        readonly Dictionary<TKey,TValue> _dic=new Dictionary<TKey,TValue>();
        public TValue this[TKey index]
        {
            get {
                TValue value=default(TValue);
                _dic.TryGetValue(index,out value);
                return value;
            }
            set { _dic[index]=value; }
        }

        public TKey this[int index]
        {
            get
            {
                return _keys[index];
            }
        }

        public int Count {get{return _keys.Length;}}

        public void OnAfterDeserialize()
        {
            _dic.Clear();
            var length=_keys.Length;
            for (int i = 0; i < length; i++)
            {
                if(i>=_values.Count)continue;
                _dic.Add(_keys[i],_values[i]);
            }
        }

        public void OnBeforeSerialize()
        {
            var length=_keys.Length;
            _values.Clear();
            for (int i = 0; i < length; i++)
            {
                TValue value=default(TValue);
                if(_keys[i]!=null)_dic.TryGetValue(_keys[i],out value);
                _values.Add(value);
            }
        }
    }
}
