using UnityEngine;
public class SpinRotate:TRNTH.MonoBehaviour{
	public float speed=30f;
	public Space type;
	void Update () {
		tra.Rotate(0,Time.deltaTime*60*speed,0,type);
	}
}
