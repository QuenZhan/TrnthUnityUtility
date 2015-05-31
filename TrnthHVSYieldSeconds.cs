using UnityEngine;
using System.Collections;

public class TrnthHVSYieldSeconds : TrnthHVSYield {
	public float seconds=1;
	public override float duration{get{return seconds;}}
}
