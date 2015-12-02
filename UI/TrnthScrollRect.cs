using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TrnthScrollRect : ScrollRect,IEndDragHandler,IBeginDragHandler,IScrollHandler {
	public event System.Action<TrnthScrollRect,PointerEventData> onBeginDrag=delegate{};
	public event System.Action<TrnthScrollRect,PointerEventData> onEndDrag=delegate{};
	public event System.Action<TrnthScrollRect,PointerEventData> onScroll=delegate{};
	public new void OnEndDrag(PointerEventData  eventData){
		Debug.Log("OnEndDrag",this);
		base.OnEndDrag(eventData);
		onEndDrag(this,eventData);
	}
	public new void OnBeginDrag(PointerEventData  eventData){
		Debug.Log("OnBeginDrag",this);
		base.OnBeginDrag(eventData);
		onBeginDrag(this,eventData);
	}
	public new void OnScroll(PointerEventData eventData){
		Debug.Log("OnScroll",this);
		base.OnScroll(eventData);
		onScroll(this,eventData);
	}
}
