using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;


namespace TRNTH.Pooling{
	[System.Serializable]
	public class Pool<T> where T:Component{
		// public T Prefab;
		// public int Limiation=3;
		[SerializeField]List<T> _Instances=new List<T>();
		public IReadOnlyList<T> Components{
			get{
				return _Instances;
				// if(_readonlyComponents==null)_readonlyComponents=_Instances.AsReadOnly();
				// return _readonlyComponents;
			}
		}
		// ReadOnlyCollection<GameObject> _radonlyRoots;
		// ReadOnlyCollection<Transform> _readonlyTransforms;
		// ReadOnlyCollection<T> _readonlyComponents;
		
		int SpawningIndex;
		// static public void PreSpawn(Transform parent,IList<T> _Instances){
		// 	_Instances.Clear();
		// 	var length=parent.childCount;
		// 	for (int i = 0; i < length; i++)
		// 	{
		// 		var ins=parent.GetChild(i).GetComponent<T>();
		// 		if(ins==null)continue;
		// 		_Instances.Add(ins);
		// 	}
		// }
		// public void PreSpawn(Transform parent){
		// 	PreSpawn(parent,_Instances);
		// 	// foreach(var e in _Instances){
		// 	// 	Object.DestroyImmediate(e);
		// 	// }
		// 	// _Instances.Clear();
		// 	// for(var i=0;i<Limiation;i++){
		// 	// 	_Instances.Add(Object.Instantiate(Prefab));
		// 	// 	PreSpawned(i,_Instances[i].gameObject);
		// 	// }
		// }
		// protected virtual void PreSpawned(int index,GameObject newGo){
		// 	newGo.SetActive(false);
		// }
		public int Spawn(){
			var Limiation=_Instances.Count;
			// if(_Instances==null 
			// ||  _Instances.Count!=Limiation 
			// || _Instances[0]==null
			// ){
			// 	PreSpawn();
			// }
			SpawningIndex=++SpawningIndex%Limiation;
			// var go=_Instances[SpawningIndex];
			// go.gameObject.SetActive(true);
			return SpawningIndex;
		}
		public T SpawnAndGetInstance(){
			var index=Spawn();
			return this.Components[index];
		}
	}
}