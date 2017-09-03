using UnityEngine;
using System.Collections;

public class TrnthConstraintFixedUpdatePrisoner : TrnthConstraintFixedUpdate {
	public enum PrisonerStatus{None,Right,Left}
	public float left=-10000;
	public float right=10000;
	public PrisonerStatus Status;
	public override void update(Vector3 pos){
		Status=PrisonerStatus.None;
		if(pos.x>right){
			pos.x=right;
			Status=PrisonerStatus.Right;
		}
		if(pos.x<left){
			pos.x=left;
			Status=PrisonerStatus.Left;
		}
		base.update(pos);
	}
}
