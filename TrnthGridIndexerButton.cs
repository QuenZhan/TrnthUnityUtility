using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthGridIndexerButton : TrnthMonoBehaviour {
	public TrnthGridIndexer indexer;
	public int index;
	void OnClick(){
		indexer.index=index;
	}
}
