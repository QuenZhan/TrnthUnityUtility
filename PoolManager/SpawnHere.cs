using UnityEngine;
using System.Collections;

public class SpawnHere : TRNTH.PoolBase{
	public GameObject prefab;
	public void execute(){
		var instance=Spawn(prefab);
		instance.transform.position=pos;
	}
	void OnEnable(){
		execute();
	}
}
