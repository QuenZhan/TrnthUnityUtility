using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrnthStateMachine{
	public TrnthStateMachine(State initialState){
		switchState(initialState);
		TrnthCoroutine.Coroutine(loop());
	}
	IEnumerator loop(){
		while(true){
			yield return new WaitForSeconds(0);
			current.update();
		}
	}
	public event System.Action<TrnthStateMachine> onSwitch=delegate{};
	public State current{get{return _state;}}
	public void switchState(State state){
		if(_state==state)return;
		if(_state!=null)_state.onExit();
		_state=state;
		_state.onEnter();
		onSwitch(this);
	}
	State _state;
	public class State{
		public readonly System.Action onEnter=delegate{};
		internal readonly System.Action update=delegate{};
		public readonly System.Action onExit=delegate{};
		public State(System.Action onEnter,System.Action update,System.Action onExit){
			this.onEnter=onEnter;
			this.onExit=onExit;
			this.update=update;
		}
	}
}
