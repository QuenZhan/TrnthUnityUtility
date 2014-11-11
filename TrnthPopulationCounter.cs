using UnityEngine;
using System.Collections;

public class TrnthPopulationCounter : MonoBehaviour {
	public TrnthPopulation population;
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
	}
	void OnDespawned(){
		// if(!population)find();
		population.now-=1;	
	}
}
