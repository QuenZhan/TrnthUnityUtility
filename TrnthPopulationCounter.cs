using UnityEngine;
using System.Collections;

public class TrnthPopulationCounter : MonoBehaviour {
	public TrnthPopulation population;
	public Transform locator;
	public string nameInRuntime;
	void find(){
		var go=GameObject.Find(nameInRuntime);
		if(go)population=go.GetComponent<TrnthPopulation>();
	}
	void Start(){
		if(!population){
			find();
		}
	}
	void OnSpawned(){
		if(!population)find();
		population.now+=1;
		population.sum+=1;
		population.locator=locator;
	}
	void OnDespawned(){
		// if(!population)find();
		population.locator=locator;
		population.now-=1;	
	}
}
