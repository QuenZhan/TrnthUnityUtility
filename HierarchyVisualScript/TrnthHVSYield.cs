using UnityEngine;
using System.Collections;

public class TrnthHVSYield : TrnthHVS {
	public virtual float duration{get{return Time.deltaTime;}}
}
