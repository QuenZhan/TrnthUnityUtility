using UnityEngine;
using System.Collections;

public interface ITrnthNarrativeModel {
	string name{get;}
	string description{get;}
	float duration{get;}
	void execute(ITrnthNarrator narrator);
}
