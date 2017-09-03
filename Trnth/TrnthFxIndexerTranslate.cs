using UnityEngine;
using System.Collections;

public class TrnthFxIndexerTranslate : TrnthFxIndexer {
	protected override void childSetup(Transform child,Vector3 direction){
		child.localPosition=direction;
	}
}
