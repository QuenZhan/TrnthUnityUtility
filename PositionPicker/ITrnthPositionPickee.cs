using UnityEngine;
using System.Collections;

public interface ITrnthPositionPickee{
	Vector3 positionWorld{get;}
	void onPosition(ITrnthPositionPicker picker);
	void onAwayPosition(ITrnthPositionPicker picker);
}
