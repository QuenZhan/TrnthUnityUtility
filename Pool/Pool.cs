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
		public GameObject Prefab;
		public int Limiation=3;
		[ContextMenuItem("PreSpawn", "PreSpawn")]
		[SerializeField]List<GameObject> _Instances=new List<GameObject>();
		readonly List<Transform> _transforms=new List<Transform>();
		readonly List<T> _components=new List<T>();
		public ReadOnlyCollection<GameObject> Roots{
			get{
				if(_radonlyRoots==null)_radonlyRoots=_Instances.AsReadOnly();
				return _radonlyRoots;
			}
		}
		public ReadOnlyCollection<Transform> Transforms{
			get{
				if(_readonlyTransforms==null)_readonlyTransforms=_transforms.AsReadOnly();
				return _readonlyTransforms;
			}
		}
		public ReadOnlyCollection<T> Components{
			get{
				if(_readonlyComponents==null)_readonlyComponents=_components.AsReadOnly();
				return _readonlyComponents;
			}
		}
		ReadOnlyCollection<GameObject> _radonlyRoots;
		ReadOnlyCollection<Transform> _readonlyTransforms;
		ReadOnlyCollection<T> _readonlyComponents;
		
		public int SpawningIndex{get;private set;}
		public virtual void PreSpawn(){
//			if(_Instances!=null && _Instances.Length>0)throw new System.InvalidOperationException();
			foreach(var e in _Instances){
				Object.DestroyImmediate(e);
			}
			_Instances.Clear();
			_transforms.Clear();
			_components.Clear();
//			_transforms.Capacity=Limiation;
//			_Instances.Capacity=Limiation;
//			_components.Capacity=Limiation;
//			_transforms=new Transform[Limiation];
//			_components=new T[Limiation];
//			Roots=System.Array.AsReadOnly(_Instances);
//			Transforms=System.Array.AsReadOnly(_transforms);
//			Components=System.Array.AsReadOnly(_components);
			for(var i=0;i<Limiation;i++){
//				_Instances[i]=Object.Instantiate(Prefab);
//				_transforms[i]=_Instances[i].transform;
//				_components[i]=_Instances[i].GetComponentInChildren<T>();
				_Instances.Add(Object.Instantiate(Prefab));
				_transforms.Add(_Instances[i].transform);
				_components.Add(_Instances[i].GetComponentInChildren<T>());
				PreSpawned(i,_Instances[i]);
			}
		}
		protected virtual void PreSpawned(int index,GameObject newGo){
			newGo.SetActive(false);
		}
		public virtual int Spawn(){
			if(_Instances==null ||  _Instances.Count!=Limiation){
				PreSpawn();
//				throw new System.InvalidOperationException("PreSpawn first");
			}
			SpawningIndex=++SpawningIndex%Limiation;
			var go=_Instances[SpawningIndex];
			go.SetActive(true);
			return SpawningIndex;
		}
	}
}