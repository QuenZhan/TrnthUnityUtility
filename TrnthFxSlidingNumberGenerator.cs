using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TrnthFxSlidingNumber))]
public class TrnthFxSlidingNumberGenerator:MonoBehaviour{
	// public enum Type{tranlation,rotation}
	// public Type type;
	public float marginDigit=20;
	public float marginNumber=40;
	public int digits;
	public UI.Text prefab;
	[ContextMenu("generate")]
	public void generate{
		TRNTH.U.cleanChildren(transform);
		var slidingNumber=GetComponent<TrnthFxSlidingNumber>();
		for(int i=0;i<digits;i++){
			var group = new GameObject("digitGroup");
			group.transform.parent=this.transform;
			group.transform.localPosition=new Vecto3(i*marginDigit,0,0);
			for(int j=0;j<10;j++){
				var ins=Instantiate(prefab) as UI.Text;
				ins.transform.parent=group.transform;
				ins.transform.localPosition=new Vecto3(0,j*marginNumber,0);
			}
		}
	}
} 