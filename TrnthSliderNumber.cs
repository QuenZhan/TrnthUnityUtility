using UnityEngine;
using System.Collections;

public class TrnthSliderNumber : MonoBehaviour {
	public int number;
	public TrnthGridIndexer digit0;
	public TrnthGridIndexer digit1;
	public TrnthGridIndexer digit2;
	void Update () {
		if(digit0)digit0.index=number%10;
		if(digit1)digit1.index=(number/10)%10;
		if(digit2)digit2.index=(number/100)%10;
	}
}
