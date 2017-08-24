using UnityEngine;
using System.Collections;

public class TrnthTwinkleSprite : MonoBehaviour {
	public SpriteRenderer srdr;
	public float speedScale=1;
	Color colorOrin;
	bool enabledOrin;
	void Awake(){
		if(!srdr)srdr=GetComponent<SpriteRenderer>();
		colorOrin=srdr.color;
		enabledOrin=enabled;
	}
	void Start () {
	}
	void OnSpawned(){
		enabled=enabledOrin;
		srdr.color=colorOrin;
	}
	void Update () {
		var color=srdr.color;
		color.a=(Mathf.Sin(Time.time*speedScale)+1)*0.5f;
		srdr.color=color;
	}
}
