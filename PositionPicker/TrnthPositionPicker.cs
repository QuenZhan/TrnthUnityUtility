using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public abstract class TrnthPositionPicker : MonoBehaviour,ITrnthPositionPicker {
	[SerializeField]Transform _locator;
	[SerializeField]protected Transform _group;
	public Vector3 position{get{
		if(_locator==null)return transform.position;
		return _locator.position;
	}}
	public event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onPicked=delegate{};
	public event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onBeginDrag=delegate{};
	public event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onEndDrag=delegate{};
	public event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onScrollTo=delegate{};
	public void onDragEnd(){
		// Debug.Log("onDragEnd",this);
		Invoke("_delayScrollTo",0.5f);
		onEndDrag(this,_pickee);
	}
	public void onDragStart(){
		scrollStop();
		CancelInvoke("_delayScrollTo");
		onBeginDrag(this,_pickee);
	}
		void _delayScrollTo(){
			if(gameObject.activeInHierarchy)scrollTo(_pickee);
		}
	public virtual void onScrollValueChange(Vector2 vec){
		if(!cooled)return;
		pick();
		// StartCoroutine(_cooldown());
	}
		IEnumerator _cooldown(){
			cooled=false;
			yield return new WaitForSeconds(0.1f);
			cooled=true;
		}bool cooled=true;
	public void pick(){
		if(pickees.Count<1 || _locator==null)return;
		pickees.Sort((a,b)=>{
			return  (_locator.position - a.positionWorld).magnitude < (_locator.position - b.positionWorld).magnitude ?-1:1;
		});
		var pickee=pickees[0];
		if(pickee==_pickee)return;
		StartCoroutine(_cooldown());
		if(_pickee!=null)_pickee.onAwayPosition(this);
		_pickee=pickee;
		_pickee.onPosition(this);
		onPicked(this,pickee);
	}
	public void scrollTo(ITrnthPositionPickee data){
		scrollStop();
		if(_scroll)_scroll.inertia=false;
		var thePickee=pickees.Find(t=>{return t==data;});
		if(thePickee==null)return;
		_posTarget=_group.localPosition;
		_posTarget.y=-thePickee.positionLocal.y;
		cooled=false;
		pickees.ForEach(t=>{
			if(t==data)t.onPosition(this);
			else t.onAwayPosition(this);
			});
		_scrollTo=true;
		_pickee=data;
		onScrollTo(this,data);
		// StartCoroutine(_scrollUpdate(_posTarget,5));
	}
	public void scrollStop(){
		_scrollTo=false;
		cooled=true;
		if(_scroll)_scroll.inertia=true;
	}
	protected abstract List<ITrnthPositionPickee> pickees{get;}
	protected virtual void OnEnable(){
		cooled=true;
	}
	protected virtual void OnDisable(){
		CancelInvoke("_delayScrollTo");
	}
	protected virtual void Awake(){
	}
	protected virtual void Update(){
		if(_scrollTo)_group.localPosition=Vector3.Lerp(_group.localPosition,_posTarget,0.2f);
	} bool _scrollTo=false;
	[ContextMenu("generate trigger event")]
	protected void _gen(){
		_scroll=_group.GetComponentInParent<ScrollRect>();
		_eventTriggerStuff(_scroll);
	}
	Vector3 _posTarget;
	void _eventTriggerStuff(ScrollRect scroll){
		if(scroll==null)return;
		var trigger=_scroll.GetComponent<EventTrigger>();
		if(trigger!=null)return;
		trigger = _scroll.gameObject.AddComponent<EventTrigger>();
		trigger.triggers.Add(entry(EventTriggerType.BeginDrag,_onDragStart));
		trigger.triggers.Add(entry(EventTriggerType.EndDrag,_onDragEnd));
		// trigger.triggers.Add(entry(EventTriggerType.Scroll,_onScroll));
	}
	EventTrigger.Entry entry(EventTriggerType type,UnityEngine.Events.UnityAction<BaseEventData> callback){
		var entry = new EventTrigger.Entry(){
			eventID = type
			,callback = new EventTrigger.TriggerEvent()
		};
		// entry.callback.AddListener(callback);
		entry.callback.AddListener((data)=>{Debug.Log("entry.callback.AddListener");});
		return entry;
	}
	public void _onDragEnd(BaseEventData data){
		onDragEnd();
	}
	public void _onDragStart(BaseEventData data){
		onDragStart();
	}
	public void _onScroll(BaseEventData data){
		onScrollValueChange(Vector2.zero);
	}
	ScrollRect _scroll;
	ITrnthPositionPickee _pickee;
}
