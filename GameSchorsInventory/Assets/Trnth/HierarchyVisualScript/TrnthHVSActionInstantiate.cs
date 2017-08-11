using UnityEngine;
using System.Collections;

public class TrnthHVSActionInstantiate : TrnthHVSAction {	
	[SerializeField] protected GameObject prefab;
	[SerializeField] bool beChild=false;
	[SerializeField] bool positionFit=true;
	[SerializeField] bool rotationFit;
	[SerializeField] protected float life;
	[SerializeField] TrnthHVSCondition onSucceed;
	[SerializeField] TrnthHVSCondition onFail;
	public GameObject instantiated{get;private set;}
	protected override void _execute(){
		var position=prefab.transform.position;
		var rotation=prefab.transform.rotation;
		Transform parent=null;
		if(positionFit)position=this.transform.position;
		if(rotationFit)rotation=this.transform.rotation;
		if(beChild)parent=this.transform;
		instantiated=create(position,rotation,parent);
		if(!instantiated){
			send(onFail);
			return;
		}
		if(onSucceed)onSucceed.send();
	}
	protected virtual GameObject create(Vector3 position,Quaternion rotation,Transform parent){
		var ins=Instantiate(prefab,position,rotation) as GameObject;
		ins.transform.parent=parent;
		if(life>0)Destroy(ins,life);
		return ins;
	}
}
