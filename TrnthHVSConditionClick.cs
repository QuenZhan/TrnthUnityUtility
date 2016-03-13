using UnityEngine;
using System.Collections;
public class TrnthHVSConditionClick : TrnthHVSCondition {
	void Start(){
		var button=GetComponent<UnityEngine.UI.Button>();
		if(!button)return;
		button.onClick.AddListener(OnClick);
	}
	void OnClick(){
		send();
	}
}
