using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;


namespace TRNTH.Pooling{
	[System.Serializable]
	public class Pool<T> {
		[SerializeField]List<T> _Instances=new List<T>();
		public IReadOnlyList<T> Components{
			get{
				return _Instances;
			}
		}
		int SpawningIndex;
		public int Spawn(){
			var Limiation=_Instances.Count;
			SpawningIndex=++SpawningIndex%Limiation;
			return SpawningIndex;
		}
		public T SpawnAndGetInstance(){
			var index=Spawn();
			return this.Components[index];
		}
	}
}