using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH
{
    [System.Serializable]public class NonAllocList<T> : INonAllocList<T>
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
                _datas[index]=value;
            }
        }
        public int Count {get{return _datas.Length;}}
    }
    public interface IReadonlyNonAllocDicionary<TKey,TValue>{
        // TValue this[TKey key]{get;}
        bool TryGetValue(TKey key,out TValue value);
    }
    public interface INonAllocDicionary<TKey,TValue>:IReadonlyNonAllocDicionary<TKey,TValue>{
        TValue this[TKey key]{set;}
    }
    public interface IKeyedItem<TKey>{
        TKey Key{get;}
        // int Index{get;set;}
    }
    [System.Serializable]
    public class KeyedNonAllocList<TKey, TValue> : INonAllocDicionary<TKey, TValue>
    ,INonAllocList<TValue>
    ,ISerializationCallbackReceiver
     where TValue : IKeyedItem<TKey>
    {
        [SerializeField]List<TValue> _values=new List<TValue>();
        readonly Dictionary<TKey,int> _keys=new Dictionary<TKey, int>();
        public TValue this[TKey index]
        {
            get
            {
                return _values[_keys[index]];
            }

            set
            {
                if(!_keys.ContainsKey(index)){
                    _values.Add(value);
                    _keys.Add(index,_values.Count-1);
                }
                _values[_keys[index]]=value;
            }
        }

        public int Count {get{return _values.Count;}}


        public TValue this[int index]
        {
            get
            {
                return _values[index];
            }

            set
            {
                _values[index]=value;
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index;
            if(_keys.TryGetValue(key,out index)){
                value=_values[index];
                return true;
            }
            value=default(TValue);
            return false;
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            _keys.Clear();
            var length=_values.Count;
            for (int i = 0; i < length; i++)
            {
                _keys.Add(_values[i].Key,i);
            }
        }
    }
    [System.Serializable]public abstract class NonAllocFixedSizeDictionary<TKey,TValue>:
    INonAllocDicionary<TKey,TValue>
    // ,IReadOnlyNonAllocList<TValue>
    {
		[SerializeField]List<TKey> _keys=new List<TKey>();
        [SerializeField]List<TValue> _values=new List<TValue>();
        public IList<TValue> Values{get{return _values;}}
        readonly Dictionary<TKey,TValue> _dic=new Dictionary<TKey,TValue>();
        public bool TryGetValue(TKey key,out TValue value){
            return _dic.TryGetValue(key,out value);
        }
        public TValue this[TKey index]
        {
            get {
                if(_keys.Count!=_dic.Count){
                    _dic.Clear();
                    Justify();
                    var length=_keys.Count;
                    for (int i = 0; i < length; i++)
                    {
                        _dic[_keys[i]]=_values[i];
                    }
                }
                return _dic[index];
            }
            set {
                if(!_keys.Contains(index)){
                    _keys.Add(index);
                    Justify();
                    _values[_keys.Count-1]=value;
                }
                else{
                    var i=_keys.IndexOf(index);
                    _values[i]=value;
                }
                _dic[index]=value;
            }
        }
        void Justify(){
            var length=_keys.Count-_values.Count;
            for (int i = 0; i < length; i++)
            {  
               _values.Add(default(TValue)) ;
            }
        }

        public TKey this[int index]
        {
            get
            {
                return _keys[index];
            }
        }

        public int Count {get{return _keys.Count;}}

        // public void OnAfterDeserialize()
        // {
        //     _dic.Clear();
        //     var length=_keys.Length;
        //     for (int i = 0; i < length; i++)
        //     {
        //         if(i>=_values.Count)continue;
        //         _dic.Add(_keys[i],_values[i]);
        //     }
        // }

        // public void OnBeforeSerialize()
        // {
        //     var length=_keys.Length;
        //     _values.Clear();
        //     for (int i = 0; i < length; i++)
        //     {
        //         TValue value=default(TValue);
        //         if(_keys[i]!=null)_dic.TryGetValue(_keys[i],out value);
        //         _values.Add(value);
        //     }
        // }

    }
}
