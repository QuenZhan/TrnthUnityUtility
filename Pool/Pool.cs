using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;


namespace TRNTH.Pooling{
//	public class Pool  {
//		public static T Spawn<T>(Component prefab
//			,Vector3 position=default(Vector3)
//			,float autdDespawnAfter=10
//			,Transform parent=null
//			,bool limited=false
//			) where T:Component{
//			throw new System.NotImplementedException();
//		}
//		public static bool Despawn(GameObject gameObject){
//			throw new System.NotImplementedException();
//		}
//	}
	[System.Serializable]
	public class Pool<T> where T:Component{
		public T Prefab;
		public int Limiation=3;
		[ContextMenuItem("PreSpawn", "PreSpawn")]
		[SerializeField]List<T> _Instances=new List<T>();
		// [HideInInspector][SerializeField]List<Transform> _transforms=new List<Transform>();
		// [HideInInspector][SerializeField]List<T> _components=new List<T>();
		// public ReadOnlyCollection<GameObject> Roots{
		// 	get{
		// 		if(_radonlyRoots==null)_radonlyRoots=_Instances.AsReadOnly();
		// 		return _radonlyRoots;
		// 	}
		// }
		// public ReadOnlyCollection<Transform> Transforms{
		// 	get{
		// 		if(_readonlyTransforms==null)_readonlyTransforms=_transforms.AsReadOnly();
		// 		return _readonlyTransforms;
		// 	}
		// }
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
			// _transforms.Clear();
			// _components.Clear();
			for(var i=0;i<Limiation;i++){
				_Instances.Add(Object.Instantiate(Prefab));
				// _transforms.Add(_components[i].transform);
				// _Instances.Add(_components[i].gameObject);
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
	}
}