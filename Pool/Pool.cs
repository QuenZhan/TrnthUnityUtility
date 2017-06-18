using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.Pooling{
	public class Pool  {
		public static T Spawn<T>(Component prefab
			,Vector3 position=default(Vector3)
			,float autdDespawnAfter=10
			,Transform parent=null
			,bool limited=false
			) where T:Component{
			throw new System.NotImplementedException();
		}
		public static bool Despawn(GameObject gameObject){
			throw new System.NotImplementedException();
		}
	}
}