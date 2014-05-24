using UnityEngine;
using System.Collections;
namespace TRNTH{
public class StageWalker : TRNTH.MonoBehaviour {
	public Transform target;
	public Transform mover;
	public float speed=1;
	Vector3 veNormal;
	Vector3 getProjectPosition(){
		var vec=Vector3.Project((mover.position-pos),veNormal);
		if(Vector3.Dot(vec,veNormal)<0)return Vector3.zero;
		return vec;
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		veNormal=(target.position-pos).normalized;
		tra.Translate(getProjectPosition()*speed);
	
	}
	void OnTriggerEnter(Collider other){
		var spawner=other.GetComponent<Spawner>();
		if(spawner){
			spawner.excute();
			Destroy(spawner.collider);
		}
	}
}
}