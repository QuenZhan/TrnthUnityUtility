using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TrnthGridIndexerButton : TrnthMonoBehaviour {
	public TrnthGridIndexer indexer;
	public int index;
	public void execute(){
		indexer.index=index;
	}
	void OnClick(){
		execute();
		// indexer.index=index;
	}
}
