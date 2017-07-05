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
		[System.NonSerialized]GameObject[] _Instances=null;
		Transform[] _transforms=null;
		T[] _components=null;
		public ReadOnlyCollection<GameObject> Roots{get;private set;}
		public ReadOnlyCollection<Transform> Transforms{get;private set;}
		public ReadOnlyCollection<T> Components{get;private set;}
		
		public int SpawningIndex{get;private set;}
		public virtual void PreSpawn(){
			if(_Instances!=null && _Instances.Length>0)throw new System.InvalidOperationException();
			_Instances=new GameObject[Limiation];
			_transforms=new Transform[Limiation];
			_components=new T[Limiation];
			Roots=System.Array.AsReadOnly(_Instances);
			Transforms=System.Array.AsReadOnly(_transforms);
			Components=System.Array.AsReadOnly(_components);
			for(var i=0;i<Limiation;i++){
				_Instances[i]=Object.Instantiate(Prefab);
				_transforms[i]=_Instances[i].transform;
				_components[i]=_Instances[i].GetComponentInChildren<T>();
				PreSpawned(i,_Instances[i]);
			}
		}
		protected virtual void PreSpawned(int index,GameObject newGo){
			newGo.SetActive(false);
		}
		public virtual int Spawn(){
			if(_Instances==null ||  _Instances.Length<1){
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