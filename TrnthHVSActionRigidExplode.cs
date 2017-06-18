using UnityEngine;
using System.Collections;

public class TrnthHVSActionRigidExplode : TrnthHVSAction {
	public Rigidbody rigid;
	public float force=10;
	public Transform point;
	protected override void _execute(){
		base._execute();
		rigid.AddExplosionForce(force,point.position,10);
	}
}
