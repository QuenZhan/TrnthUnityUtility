using UnityEngine;
using System.Collections;

public class TrnthHVSActionRigidPusher : TrnthHVSAction {
	public TrnthHVSConditionCollider colliderSource;
	public Transform self;
	public string collideTag;
	public float force=10;
	protected override void _execute(){
		base._execute();
		var col=colliderSource.col;
		if(col.gameObject.tag==collideTag){
			var rigid=col.transform.parent.GetComponent<Rigidbody>();
			var vec=rigid.transform.position-self.position;
			rigid.AddForce(vec.normalized*force);

		}
	}
}
