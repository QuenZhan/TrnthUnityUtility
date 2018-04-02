using System.Collections.Generic;
using UnityEngine;
namespace TRNTH
{
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
    }
}
