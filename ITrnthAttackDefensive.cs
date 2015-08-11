using UnityEngine;
using System.Collections;

public interface ITrnthAttackDefensive {
	float point{get;}
	float resistence{get;}
	float reduction{get;}

	string[] tags{get;}

	Transform tra{get;}
}