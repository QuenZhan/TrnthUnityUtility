using UnityEngine;
using System.Collections;

public class TrnthSlidingNumber : MonoBehaviour {
	public int number;
	public TrnthGridIndexer[] digits;
	public void apply(){
		for(int i=0;i<digits.Length;i++){
			var digit=digits[i];
			digit.index=(Mathf.Abs(number)/(int)Mathf.Pow(10,i))%10;
		}
	}
	int _number;
	void Update(){
		if(number!=_number){
			apply();
			_number=number;
		}
	}
}
