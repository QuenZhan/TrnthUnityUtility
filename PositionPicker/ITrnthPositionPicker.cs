using UnityEngine;
using System.Collections;

public interface ITrnthPositionPicker {
	event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onPicked;
}
