using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;


namespace TRNTH.Pooling{
	[System.Serializable]
	public class Pool<T> {
		[SerializeField]List<T> _Instances=new List<T>();
		public IReadOnlyList<T> Instances{
			get{
				return _Instances;
			}
		}
		int SpawningIndex;
		public T Spawn(){
			var Limiation=_Instances.Count;
			SpawningIndex=++SpawningIndex%Limiation;
			var index=SpawningIndex;
			return _Instances[index];
		}
	}
}