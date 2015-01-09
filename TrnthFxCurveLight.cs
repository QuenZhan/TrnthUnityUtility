using UnityEngine;
using System.Collections;

public class TrnthFxCurveLight : TrnthFxCurve {
	public enum Property{intensity,range}
	public Light targetLight;
	public Property property;
	protected override void update(){
		var value=this.curveValue;
		switch(property){
		case Property.intensity:targetLight.intensity=value;break;
		case Property.range:targetLight.range=value;break;
		}
	}
}