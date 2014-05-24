using UnityEngine;
using System.Collections;

public class Spawner : TRNTH.PoolBase{
	public GameObject prefab;
	public void SpawnHere(){
		var instance=Spawn(prefab);
		instance.transform.position=pos;
	}
}
