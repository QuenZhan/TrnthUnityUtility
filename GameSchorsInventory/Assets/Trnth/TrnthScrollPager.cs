using UnityEngine;
using System.Collections;

public class TrnthScrollPager : MonoBehaviour {
	public TrnthGridIndexer indexer;
	public float delay=0.5f;
	public void execute(){
		indexer.setRounded();
		indexer.enabled=true;
	}
	void OnPress(bool yes){
		if(yes){
			CancelInvoke();
			indexer.enabled=false;
		}else{
			Invoke("execute",delay);
		}

	}
}
