using UnityEngine;
using System.Collections;

public interface ITrnthPositionPickee{
	Vector3 positionWorld{get;}
	Vector3 positionLocal{get;}
	event System.Action<ITrnthPositionPickee> onPositioned;
	void onPosition(ITrnthPositionPicker picker);
	void onAwayPosition(ITrnthPositionPicker picker);
}
