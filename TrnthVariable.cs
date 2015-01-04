using UnityEngine;
using System.Collections;

public class TrnthVariable : MonoBehaviour {
	public Component value;
	public TrnthHVSCondition onChange;
	public Component state{get;private set;}
	public virtual bool transit(Component state){
		var yes=write(state);
		if(yes)this.state=state;
		return yes;
	}
	public T read<T>() where T:Component{
		var value=this.value as T;
		if(value)return value;
		value=this.value.GetComponent<T>();
		return value;
	}
	public bool write(Component component){
		if(value==component)return false;
		value=component;
		if(onChange)onChange.send();
		return true;
	}
}