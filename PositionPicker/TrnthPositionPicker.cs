using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class TrnthPositionPicker : ITrnthPositionPicker {
	[SerializeField]Transform _locator;
	[SerializeField]protected Transform _group;

	public TrnthPositionPicker(Transform group,Transform locator,System.Func<ITrnthPositionPickee[]> pickees){
		_locator=locator;
		_group=group;
//		this.pickees=pickees;
		_getPickes=pickees;
	}
	System.Func<ITrnthPositionPickee[]> _getPickes;
	public Vector3 position{get{
		return _locator.position;
	}}
	public event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onPicked=delegate{};
	public event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onBeginDrag=delegate{};
	public event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onEndDrag=delegate{};
	public event System.Action<ITrnthPositionPicker,ITrnthPositionPickee> onScrollTo=delegate{};
	void onDragEnd(){
		onEndDrag(this,_pickee);
		magneted=true;
		// _delayScrollTo();
	}
	void onDragStart(){
		scrollStop();
		onBeginDrag(this,_pickee);
		magneted=false;
	}
		// void _delayScrollTo(){
		// 	if(gameObject.activeInHierarchy)scrollTo(_pickee);
		// }
	public virtual void onScrollValueChange(Vector2 vec){
		pick();
		if((vec-_vec).magnitude*pickees.Length<0.01f && magneted)scrollTo(_pickee);
		_vec=vec;
	}
	Vector2 _vec;
	bool magneted;
	void pick(){
		var pickees=new List<ITrnthPositionPickee>(this.pickees);
		if(pickees.Count<1 || _locator==null || _scrollTo)return;
		pickees.Sort((a,b)=>{
			return  (_locator.position - a.positionWorld).magnitude < (_locator.position - b.positionWorld).magnitude ?-1:1;
		});
		var pickee=pickees[0];
		if(pickee==_pickee)return;
		// Debug.Log("ddd",this);
		if(_pickee!=null)_pickee.onAwayPosition(this);
		_pickee=pickee;
		_pickee.onPosition(this);
		onPicked(this,pickee);
	}
	public void scrollTo(ITrnthPositionPickee data){
		if(data==null){
			Debug.Log("Pickee==null");
			return;
		}
		scrollStop();
		if(_scroll)_scroll.inertia=false;
		var thePickee=data;
		// var thePickee=pickees.Find(t=>{return t==data;});
		_posTarget=_group.localPosition;
		_posTarget.y=-thePickee.positionLocal.y;
		// cooled=false;
		_scrollTo=true;
		_pickee=data;
		onScrollTo(this,data);
		TrnthCoroutine.Invoke(()=>{_scrollTo=false;},1);
		// StartCoroutine(_scrollUpdate(_posTarget,5));
	}
	public void scrollStop(){
		_scrollTo=false;
		// cooled=true;
		if(_scroll)_scroll.inertia=true;
	}
	protected virtual ITrnthPositionPickee[] pickees{get{return _getPickes();}}
	protected virtual void OnEnable(){
		// cooled=true;
		scrollTo(_pickee);
	}
	protected virtual void OnDisable(){
		// CancelInvoke("_delayScrollTo");
	}
	protected virtual void Awake(){
		_gen();
		// _scrollRect.gameObject.AddComponent<
	}
	protected virtual void Update(){
		if(_scrollTo)_group.localPosition=Vector3.Lerp(_group.localPosition,_posTarget,0.2f);
	} bool _scrollTo=false;
	[ContextMenu("generate trigger event")]
	protected void _gen(){
		if(_scroll==null)return;
		// _scroll=_group.GetComponentInParent<ScrollRect>();
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
		// trigger.triggers.Add(entry(EventTriggerType.EndDrag,_onDragEnd));
		trigger.triggers.Add(entry(EventTriggerType.Drag,_onScroll));
	}
	EventTrigger.Entry entry(EventTriggerType type,UnityEngine.Events.UnityAction<BaseEventData> callback){
		var entry = new EventTrigger.Entry(){
			eventID = type
			,callback = new EventTrigger.TriggerEvent()
		};
		entry.callback.AddListener(callback);
		// entry.callback.AddListener((data)=>{Debug.Log("entry.callback.AddListener");});
		return entry;
	}
	void _onDragEnd(BaseEventData data){
		// Debug.Log("_onDragEnd",this);
		onDragEnd();
	}
	void _onDragStart(BaseEventData data){
		// Debug.Log("_onDragStart",this);
		onDragStart();
	}
	void _onScroll(BaseEventData data){
		// Debug.Log("_onScroll",this);
		pick();
		// onScrollValueChange(Vector2.zero);
	}
	public ScrollRect _scroll;
	ITrnthPositionPickee _pickee;
}
