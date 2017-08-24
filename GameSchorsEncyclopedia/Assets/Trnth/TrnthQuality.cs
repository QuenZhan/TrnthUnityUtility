using UnityEngine;
using System.Collections;

public class TrnthQuality : MonoBehaviour {
	// [SerializeField]
	public void onChange(float index){
		// setQuality((int)index);
	}
	public void setQuality(int index){
		QualitySettings.SetQualityLevel(index,true);
	}
}
