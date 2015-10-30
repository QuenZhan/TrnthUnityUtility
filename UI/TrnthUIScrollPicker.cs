using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class TrnthUIScrollPicker : MonoBehaviour {
	[SerializeField]RectTransform _group;
	[SerializeField]float _delay=2f;
	public event System.Action<TrnthUIScrollPicker,GameObject> onPick=delegate{};
	public void OnDrag(PointerEventData data){
		enabled=false;
		// pick();
		CancelInvoke("_wait");
		Invoke("_wait",_delay);
	}
	public void refresh(){
		foreach(RectTransform e in _group){
			if(e==null)continue;
			_rects.Add(e as RectTransform);
		}
	}
	public void onValueChanged(Vector2 vec){
		pick();
	}
	public void pick(){
		// refresh();
		_rects.Sort((a,b)=>{
			if(a==null)return 1;
			if(b==null)return -1;
			return  (this.transform.position - a.position).magnitude < (this.transform.position - b.position).magnitude ?-1:1;
		});
		var picked=_rects[0];
		if(_picked==picked)return;
		_picked=picked;
		onPick(this,picked.gameObject);
		_targetCoor=picked.anchoredPosition*-1;
		foreach(var e in picked.GetComponents<MonoBehaviour>()){
			var pickee=e as ITrnthUIScrollPickee;
			if(pickee==null)continue;
			pickee.pick(this);
		}
	}
	protected void Start(){
		refresh();
	}
	RectTransform _picked;
	List<RectTransform> _rects=new List<RectTransform>();
	// [SerializeField]
	Vector2 _targetCoor;
	void _wait(){
		enabled=true;
	}
	void Update(){
		_group.localPosition=Vector2.Lerp(_group.localPosition,_targetCoor,0.2f);
	}
}
