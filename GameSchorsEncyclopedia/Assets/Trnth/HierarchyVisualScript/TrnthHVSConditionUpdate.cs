// 因為效能考量不建議使用 , not recommanded for performance reason 

using UnityEngine;
using System.Collections;

public class TrnthHVSConditionUpdate : TrnthHVSCondition {
	void Update(){
		send();
	}
}