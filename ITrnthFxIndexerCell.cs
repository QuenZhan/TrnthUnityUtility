using UnityEngine;
using System.Collections;

public interface ITrnthFxIndexerCell {
	int index{get;set;}
	void onIndexIn(TrnthFxIndexer indexer);
	void onIndexOut(TrnthFxIndexer indexer);
}
