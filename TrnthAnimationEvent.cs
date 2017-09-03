using UnityEngine;
using System.Collections;

public class TrnthAnimationEvent : MonoBehaviour {
	public event System.Action<TrnthAnimationEvent> onEvent=delegate{};
	void evetnTriggers(){
		onEvent(this);
	}
}
