using System.Collections.Generic;
using UnityEngine;
namespace TRNTH
{
    public class NonAllocList<T> : INonAllocList<T>
    {
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
        // TValue this[TKey key]{get;}
    }
    public interface INonAllocDicionary<TKey,TValue>:IReadonlyNonAllocDicionary<TKey,TValue>{
        TValue this[TKey key]{set;}
    }
    public class MutableNonAllocDictionary<TKey,TValue>:INonAllocDicionary<TKey,TValue>,IReadOnlyNonAllocList<TKey>{
        readonly Dictionary<TKey,TValue> _dictionary=new Dictionary<TKey,TValue>();
        readonly List<TKey> _keys=new List<TKey>();

        public TValue this[TKey key]
        {
            // get
            // {
            //     return _dictionary[key];
            // }

            set
            {
                if(!_dictionary.ContainsKey(key)){
                    _keys.Add(key);
                }
                _dictionary[key]=value;
            }
        }

        public TKey this[int index] {
            get{
                return _keys[index];
            }
        }

        public int Count{get{return _keys.Count;}}

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key,out value);
        }
    }
    public abstract class NonAllocFixedSizeDictionary<TKey,TValue>:ISerializationCallbackReceiver
    ,INonAllocDicionary<TKey,TValue>
    ,IReadOnlyNonAllocList<TKey>
    {
		[SerializeField]TKey[] _keys;
        [SerializeField]List<TValue> _values;
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dic.TryGetValue(key,out value);
        }
        readonly Dictionary<TKey,TValue> _dic=new Dictionary<TKey,TValue>();
        public TValue this[TKey index]
        {
            // get {
            //     TValue value=default(TValue);
            //     _dic.TryGetValue(index,out value);
            //     return value;
            // }
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
