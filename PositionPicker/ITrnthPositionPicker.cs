using UnityEngine;
using System.Collections;

public interface ITrnthPositionPicker {
	event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onPicked;
	event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onEndDrag;
	event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onBeginDrag;
	event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onScrollTo;
	Vector3 position{get;}
	void scrollTo(ITrnthPositionPickee pickee);
}
