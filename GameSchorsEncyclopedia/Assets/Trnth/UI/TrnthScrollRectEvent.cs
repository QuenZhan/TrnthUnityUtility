using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TrnthScrollRectEvent : MonoBehaviour,IEndDragHandler,IBeginDragHandler {
	public event System.Action<TrnthScrollRectEvent,PointerEventData> onBeginDrag=delegate{};
	public event System.Action<TrnthScrollRectEvent,PointerEventData> onEndDrag=delegate{};
	public void OnEndDrag(PointerEventData  eventData){
		Debug.Log("OnEndDrag",this);
		onEndDrag(this,eventData);
	}
	public void OnBeginDrag(PointerEventData  eventData){
		Debug.Log("OnBeginDrag",this);
		onBeginDrag(this,eventData);
	}

}
