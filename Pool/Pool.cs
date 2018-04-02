using System.Collections;
using UnityEngine;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TRNTH.Pooling
{
	public static class Extenstion{
		public static void Init(this IList<ILimitedSpawnee> list){
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				list[i].IsSpawned=false;
			}
		}
	}
    [System.Serializable]
	public class Pool<T>:IReadOnlyNonAllocList<T> where T:ISpawnee{
	
		[SerializeField]T[] _Instances=new T[0];
		public IReadOnlyNonAllocList<T> Instances{
			get{
				return this;
			}
		}

        public int Count {get{return _Instances.Length;}}

        public T this[int index]
        {
            get
            {
                return _Instances[index];
            }
        }

        [SerializeField]int _SpawningIndex;
		public T Spawn(){
			var Limiation=_Instances.Length;
			_SpawningIndex=++_SpawningIndex%Limiation;
			var index=_SpawningIndex;
			_Instances[index].Spawning();
			return _Instances[index];
		}
	}
	public interface ISpawnee
	{
		void Spawning();
	}
	public interface ILimitedSpawnee:ISpawnee{
		bool IsSpawned{get;set;}
	}
	public class ComponentsPool<T> :Pool<T> where T:Component,ISpawnee{
		public void UnparentAll(){
			for (int i = 0; i < Instances.Count; i++)
			{
				Instances[i].transform.parent=null;
				Instances[i].transform.position=-Vector2.up*10000;
			}
		}
	}
	public class FIFOPool<T>:IReadOnlyNonAllocList<T> where T:ISpawnee{
	
		[SerializeField]T[] _Instances=new T[0];
		public IReadOnlyNonAllocList<T> Instances{
			get{
				return this;
			}
		}

        public int Count {get{return _Instances.Length;}}

        public T this[int index]
        {
            get
            {
                return _Instances[index];
            }
        }

        [SerializeField]int _SpawningIndex;
		public T Spawn(){
			var Limiation=_Instances.Length;
			_SpawningIndex=++_SpawningIndex%Limiation;
			var index=_SpawningIndex;
			_Instances[index].Spawning();
			return _Instances[index];
		}
	}
	// public class LimitedPool<T> where T:ILimitedSpawnee{
	// 	[SerializeField]T[] _Instances=new T[0];
	// 	[SerializeField]int _index;
	// 	public bool TrySpawn(out T instance){
	// 		var length=_Instances.Length;
	// 		for (int i = _index; i < length; i++)
	// 		{
	// 			if(_Instances[_index].IsSpawned){
	// 				_index=++_index%length;
	// 				continue;
	// 			}
	// 			_Instances[_index].IsSpawned=true;
	// 			_Instances[_index].Spawning();
	// 			instance=_Instances[_index];
	// 			return true;
	// 		}
	// 		instance=default(T);
	// 		return false;
	// 	}
	// }
}