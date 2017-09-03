using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RunTimeEventReciever : MonoBehaviour {
	[SerializeField]GameObject _target;
	// Use this for initialization
	void Start () {
		var eventTrigger=_target.AddComponent<EventTrigger>();
		// var entry=new Entry(){eventID=EventTriggerType.Drag,callback=new EventTrigger.TriggerEvent()};
		var entry = new EventTrigger.Entry(){
			eventID = EventTriggerType.Drag
			,callback = new EventTrigger.TriggerEvent()
		};
		// entry.callback.AddListener(callback);
		entry.callback.AddListener((data)=>{Debug.Log("entry.callback.AddListener");});
		eventTrigger.triggers.Add(entry);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
