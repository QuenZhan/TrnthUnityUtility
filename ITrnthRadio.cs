using UnityEngine;
using System.Collections;

public interface ITrnthRadio:IReadonlyTrnthRadio  {
	new float rate{get;set;}
	new float value{get;set;}
	new float length{get;set;}
	float min{get;set;}
	float max{get;set;}
	void clamp();
	event System.Action<ITrnthRadio> onChange;
}
