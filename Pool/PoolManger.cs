using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
namespace TRNTH.Pooling{
	
	public class PoolManger<T> : MonoBehaviour where T:Component{
		[SerializeField]GameObject Prefab;
		[SerializeField]int _Limiation=3;
		public int Limiation{get{return _Limiation;}}
		GameObject[] _Instances=null;
		[SerializeField]Transform[] _transforms=null;
		T[] _components=null;
		public ReadOnlyCollection<GameObject> Roots{get{return System.Array.AsReadOnly(_Instances);}}
		public ReadOnlyCollection<Transform> Transforms{get{return System.Array.AsReadOnly(_transforms);}}
		public ReadOnlyCollection<T> Components{get{return System.Array.AsReadOnly(_components);}}

		public int SpawningIndex{get;private set;}
		public virtual void PreSpawn(){
			if(_Instances!=null)throw new System.InvalidOperationException();
			_Instances=new GameObject[Limiation];
			_transforms=new Transform[Limiation];
			_components=new T[Limiation];
			for(var i=0;i<Limiation;i++){
				_Instances[i]=Instantiate(Prefab);
				_transforms[i]=_Instances[i].transform;
				_components[i]=_Instances[i].GetComponentInChildren<T>();
				PreSpawned(i,_Instances[i]);
			}
		}
		protected virtual void PreSpawned(int index,GameObject newGo){
			newGo.SetActive(false);
		}
		public virtual int Spawn(){
			if(_Instances==null)throw new System.InvalidOperationException("PreSpawn first");
			SpawningIndex=++SpawningIndex%Limiation;
			var go=_Instances[SpawningIndex];
			go.SetActive(true);
			return SpawningIndex;
		}
	}
}