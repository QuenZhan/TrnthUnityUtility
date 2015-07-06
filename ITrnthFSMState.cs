using UnityEngine;
using System.Collections;

public interface ITrnthFSMState{
	Transform transform{get;}
	void onEnter(TrnthFSM fsm);
}
