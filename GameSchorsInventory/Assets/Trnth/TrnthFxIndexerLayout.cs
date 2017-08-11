using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(TrnthFxIndexer))]
public class TrnthFxIndexerLayout : MonoBehaviour {
	[SerializeField]List<ITrnthFxIndexerCell> cells=new List<ITrnthFxIndexerCell>();
	TrnthFxIndexer _indexer;
	void Awake(){
		_indexer=GetComponent<TrnthFxIndexer>();
		_indexer.onChanged+=onChanged;
		foreach(Transform e in transform){
			var cell=e.GetComponent<MonoBehaviour>() as ITrnthFxIndexerCell;
			if(cell==null)continue;
			cell.index=e.GetSiblingIndex();
			// e.position=_indexer.localPositionAt(cell.index);
			cells.Add(cell);
		}
		onChanged(_indexer,_indexer.index);
	}
	void onChanged(TrnthFxIndexer indexer,int index){
		foreach(var e in cells){
			if(e.index==index)e.onIndexIn(indexer);
			else e.onIndexOut(indexer);
		}
		// for(var i==0;i<transform.childCount;i++){
		// 	var cell=transform.GetChild[i].GetComponent<MonoBehaviour>() as ITrnthFxIndexerCell;
		// 	if(cell==null)continue;
		// 	if(i==index)cell.onIndexIn(_indexer,index);
		// 	else cell.onIndexOut(_indexer,index);				
		// }		
	}
}
