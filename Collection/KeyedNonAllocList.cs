using System.Collections.Generic;
using UnityEngine;
namespace TRNTH
{
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
}
