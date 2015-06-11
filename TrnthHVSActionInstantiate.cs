using UnityEngine;
using System.Collections;

public class TrnthHVSActionInstantiate : TrnthHVSAction {	
	public GameObject prefab;
	public bool beChild=false;
	public bool positionFit=true;
	public bool rotationFit;
	public TrnthHVSCondition onSucceed;
	public TrnthHVSCondition onFail;
	public GameObject instantiated{get;private set;}
	protected override void _execute(){
		instantiated=Instantiate(prefab) as GameObject;
		if(!instantiated){
			if(onFail)onFail.send();
			return;
		}
		if(positionFit)instantiated.transform.position=transform.position;
		if(rotationFit)instantiated.transform.eulerAngles=transform.eulerAngles;
		if(beChild)instantiated.transform.parent=transform;
		if(onSucceed)onSucceed.send();
	}
}
