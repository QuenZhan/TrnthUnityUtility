using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TrnthFxSlidingNumber))]
public class TrnthFxSlidingNumberGenerator:MonoBehaviour{
	public float marginDigit=20;
	public float marginNumber=40;
	public int digits;
	public Color color;
	public UnityEngine.UI.Text prefab;
	[ContextMenu("collor apply")]
	public void applyColor(){
		foreach(var e in GetComponentsInChildren<Text>()){
			e.color=this.color;
		}
	}
	[ContextMenu("generate")]
	public void generate(){
		TRNTH.U.cleanChildren(transform);
		var list=new List<TrnthFxIndexer>();
		for(int i=0;i<digits;i++){
			var group = new GameObject("digitGroup"+i);
			group.transform.SetParent(this.transform);
			group.transform.localPosition=new Vector3(-i*marginDigit,0,0);
			group.transform.localScale=Vector3.one;
			group.transform.localEulerAngles=Vector3.zero;
			for(int j=0;j<10;j++){
				var ins=Instantiate(prefab) as UnityEngine.UI.Text;
				ins.transform.SetParent(group.transform);
				ins.transform.localScale=Vector3.one;
				ins.transform.localPosition=Vector3.zero;
				ins.transform.localEulerAngles=Vector3.zero;
				ins.text=j.ToString();
				ins.name=ins.text;
				// ins.transform.localPosition=new Vector3(0,j*marginNumber,0);
			}
			var indexer=group.AddComponent<TrnthFxIndexerTranslate>();
			indexer.length=10;
			indexer.margin=marginNumber;
			indexer.setup();
			list.Add(indexer);
		}
		var slidingNumber=GetComponent<TrnthFxSlidingNumber>();
		slidingNumber.digits=list.ToArray();
	}
} 