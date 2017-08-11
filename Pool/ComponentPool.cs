using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
namespace TRNTH.Pooling{	
	public abstract class ComponentPool<T> : MonoBehaviour where T:Component{
		public T Prefab;
		[SerializeField]int _Limiation=3;
		public int Limiation{get{return _Limiation;}}
		// public ReadOnlyCollection<GameObject> Roots{get{return Pool.Roots;}}
		// public ReadOnlyCollection<Transform> Transforms{get{return Pool.Transforms;}}
		public ReadOnlyCollection<T> Components{get{return Pool.Components;}}
		public int SpawningIndex{get{return Pool.SpawningIndex;}}
		public virtual void PreSpawn(){
			Pool.Prefab=Prefab;
			Pool.Limiation=_Limiation;
			Pool.PreSpawn();
		}
		public virtual int Spawn(){
			return Pool.Spawn();
		}
		public Pool<T> Pool=new Pool<T>();
	}
}