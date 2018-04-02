using System.Collections.Generic;
using UnityEngine;


namespace TRNTH.Pooling
{
    public class PoolMananger:MonoBehaviour{
		[SerializeField]GameObject _Prefab;
		[SerializeField]GameObject[] _instances;
		[SerializeField]int _index;
		private void Start() {
			var length=_instances.Length;
			for (int i = 0; i < length; i++)
			{
				_instances[i].transform.SetParent(null);
			}
		}
		[ContextMenu("Generate")]void Generate(){
			var length=_instances.Length;
			for (int i = 0; i < length; i++)
			{
				if(_instances[i])DestroyImmediate(_instances[i]);
				UnityEditor.PrefabUtility.GetPrefabObject(_Prefab);
				// UnityEditor.PrefabUtility.IsComponentAddedToPrefabInstance
				if(string.IsNullOrEmpty(_Prefab.scene.name)){
					_instances[i]=UnityEditor.PrefabUtility.InstantiatePrefab(_Prefab) as GameObject;
				}
				else{
					_instances[i]=Instantiate(_Prefab);
				}
				_instances[i].transform.SetParent(this.transform);
				// _instances[i].transform.Freeze();
			}
		}
		public void GetSpawnees<T>(List<T> _list)where T:Component,ISpawnee{
			_list.Clear();
			var length=_instances.Length;
			for (int i = 0; i < length; i++)
			{
				_list.Add(_instances[i].GetComponent<T>());
			}
		}
		public T FifoSpawn<T>(IList<T> list) where T:ISpawnee{
			var Limiation=_instances.Length;
			_index=++_index%Limiation;
			var index=_index;
			list[index].Spawning();
			return list[index];
		}
		public void Init<T>(IList<T> list) where T:ILimitedSpawnee{
			var length=list.Count;
			for (int i = 0; i < length; i++)
			{
				list[i].IsSpawned=false;
			}
		}
		public bool TrySpawn<T>(IList<T> list,out T instance) where T:ILimitedSpawnee{
			var length=_instances.Length;
			for (int i = _index; i < length; i++)
			{
				if(list[_index].IsSpawned){
					_index=++_index%length;
					continue;
				}
				list[_index].IsSpawned=true;
				list[_index].Spawning();
				instance=list[_index];
				return true;
			}
			instance=default(T);
			return false;
		}
	}
}