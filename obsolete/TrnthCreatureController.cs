using UnityEngine;
using System.Collections;

public class TrnthCreatureController : MonoBehaviour {
	public TrnthCreature creature;
	public GameObject moveTarget;
	void OnInputDown(){
		creature.targetPersitant=moveTarget;
	}
	void OnInputUp(){
		creature.targetPersitant=null;
	}
}
