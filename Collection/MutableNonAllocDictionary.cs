using System.Collections.Generic;
namespace TRNTH
{
    public class MutableNonAllocDictionary<TKey,TValue>:INonAllocDicionary<TKey,TValue>,IReadOnlyNonAllocList<TKey>{
        readonly Dictionary<TKey,TValue> _dictionary=new Dictionary<TKey,TValue>();
        readonly List<TKey> _keys=new List<TKey>();

        public TValue this[TKey key]
        {

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
}
