using UnityEngine;
using System.Collections;

public class TrnthHVSActionQuality : TrnthHVSAction {
	[SerializeField]int index;
	protected override void _execute(){
		setQuality(index);
	}
	public void setQuality(int index){
		QualitySettings.SetQualityLevel(index,true);
	}
}
