using UnityEngine;
using System.Collections;

public class TrnthHVSActionFxIndexer : TrnthHVSAction {
	[SerializeField]TrnthFxIndexer indexer;
	[SerializeField]int index;
	protected override void _execute(){
		indexer.index=index;
	}
}
