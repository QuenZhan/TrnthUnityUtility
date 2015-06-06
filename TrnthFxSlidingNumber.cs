using UnityEngine;
using System.Collections;

public class TrnthFxSlidingNumber : TrnthFx {
	public int number;
	public TrnthFxIndexer[] digits;
	[ContextMenu("apply")]
	void apply_editor(){
		for(int i=0;i<digits.Length;i++){
			var digit=digits[i];
			digit.index=(Mathf.Abs(number)/(int)Mathf.Pow(10,i))%10;
			digit.execute();
		}

	}
	public void apply(){
		for(int i=0;i<digits.Length;i++){
			var digit=digits[i];
			digit.index=(Mathf.Abs(number)/(int)Mathf.Pow(10,i))%10;
		}
	}
	int _number;
	protected override void update(){
		if(number!=_number){
			apply();
			_number=number;
		}
	}
}
