using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;


namespace TRNTH.Pooling{
	[System.Serializable]
	public class Pool<T> where T:Component{
		public T Prefab;
		public int Limiation=3;
		[ContextMenuItem("PreSpawn", "PreSpawn")]
		[SerializeField]List<T> _Instances=new List<T>();
		public ReadOnlyCollection<T> Components{
			get{
				if(_readonlyComponents==null)_readonlyComponents=_Instances.AsReadOnly();
				return _readonlyComponents;
			}
		}
		ReadOnlyCollection<GameObject> _radonlyRoots;
		ReadOnlyCollection<Transform> _readonlyTransforms;
		ReadOnlyCollection<T> _readonlyComponents;
		
		public int SpawningIndex{get;private set;}
		public virtual void PreSpawn(){
			foreach(var e in _Instances){
				Object.DestroyImmediate(e);
			}
			_Instances.Clear();
			for(var i=0;i<Limiation;i++){
				_Instances.Add(Object.Instantiate(Prefab));
				PreSpawned(i,_Instances[i].gameObject);
			}
		}
		protected virtual void PreSpawned(int index,GameObject newGo){
			newGo.SetActive(false);
		}
		public virtual int Spawn(){
			if(_Instances==null 
			||  _Instances.Count!=Limiation 
			|| _Instances[0]==null
			){
				PreSpawn();
//				throw new System.InvalidOperationException("PreSpawn first");
			}
			SpawningIndex=++SpawningIndex%Limiation;
			var go=_Instances[SpawningIndex];
			go.gameObject.SetActive(true);
			return SpawningIndex;
		}
		public T SpawnAndGetInstance(){
			var index=Spawn();
			return this.Components[index];
		}
	}
}