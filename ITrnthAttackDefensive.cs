using UnityEngine;
using System.Collections;

public interface ITrnthAttackDefensive {
	ITrnthRadio hp{get;}
	float point{get;}
	float resistence{get;}
	float reduction{get;}
	string[] tags{get;}

	Transform tra{get;}
	bool inControl{get;}
	IDSBuff buffAdd(string name);
	bool contains(string name);
}