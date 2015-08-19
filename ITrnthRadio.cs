using UnityEngine;
using System.Collections;

public interface ITrnthRadio  {
	float rate{get;set;}
	float value{get;set;}
	float length{get;set;}
	void clamp();
	event System.Action<ITrnthRadio> onChange;
}
