using UnityEngine;
using System.Collections;

public class TrnthHVSActionLayerSet : TrnthHVSAction {
	public GameObject target;
	public string layerName;
	protected override void _execute(){
		target.layer=LayerMask.NameToLayer(layerName);
	}
}
