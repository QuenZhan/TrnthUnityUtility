using UnityEngine;
using System.Collections;
public class DespawnTarget : TRNTH.PoolBase {
	public GameObject targetToDespawn;
	public bool executeOnSpawned=true;
	public float delay;
	public virtual void excute(){
		execute();
	}
	public virtual void execute(){
		enabled=false;
		StartCoroutine(boo());
	}
	public override void Awake(){
		base.Awake();
		if(!targetToDespawn)targetToDespawn=gameObject;
	}
	IEnumerator boo(){
        yield return new WaitForSeconds(delay);
		Despawn(targetToDespawn.transform);
    }
	void OnEnable(){
		execute();
	}
	public virtual void OnSpawned(){
		if(executeOnSpawned)execute();
	}
}
