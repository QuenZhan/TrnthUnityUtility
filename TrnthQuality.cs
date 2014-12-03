using UnityEngine;
using System.Collections;

public class TrnthQuality : MonoBehaviour {
	public void setQuality(int index){
		QualitySettings.SetQualityLevel(index,true);
	}
}
