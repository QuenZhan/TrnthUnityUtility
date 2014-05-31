using UnityEngine;
using System.Collections;

public class SpawnHere : TRNTH.PoolBase{
	public GameObject prefab;
	public float probability=1;
	public void execute(){
		if(probability<Random.value)return;
		var instance=Spawn(prefab);
		instance.transform.position=pos;
		enabled=false;
	}
	void OnEnable(){
		execute();
	}
}
