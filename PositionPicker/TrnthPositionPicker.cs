using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class TrnthPositionPicker : MonoBehaviour,ITrnthPositionPicker {
	[SerializeField]Transform _locator;
	public Vector3 position{get{
		if(_locator==null)return transform.position;
		return _locator.position;
	}}
	public event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onPicked=delegate{};
	public virtual void onScrollValueChange(Vector2 vec){
		pick();
	}
	public void pick(){
		if(pickees.Count<1 || _locator==null)return;
		pickees.Sort((a,b)=>{
			return  (_locator.position - a.positionWorld).magnitude < (_locator.position - b.positionWorld).magnitude ?-1:1;
		});
		var pickee=pickees[0];
		if(pickee==_pickee)return;
		if(_pickee!=null)_pickee.onAwayPosition(this);
		_pickee=pickee;
		_pickee.onPosition(this);
		onPicked(this,pickee);
	}
	protected abstract List<ITrnthPositionPickee> pickees{get;}
	ITrnthPositionPickee _pickee;
}
