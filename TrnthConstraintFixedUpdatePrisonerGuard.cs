using UnityEngine;
using System.Collections;

public class TrnthConstraintFixedUpdatePrisonerGuard : MonoBehaviour {
	public enum Border{left,right}
	public TrnthConstraintFixedUpdatePrisoner prisoner;
	public string find="CameraFoot";
	[SerializeField]public Border border;
	public void execute(){
		if(!prisoner){
			var go=GameObject.Find(find);
			if(!go){
				Invoke("OnEnable",0.1f);
				return;
			}
			prisoner=go.GetComponent<TrnthConstraintFixedUpdatePrisoner>();			
		}
		switch(border){
		case Border.left	:prisoner.left	=transform.position.x;break;
		case Border.right	:prisoner.right	=transform.position.x;break;
		}
	}
	void free(){
		if(!prisoner)return;
		switch(border){
		case Border.left	:prisoner.left	=-Mathf.Infinity;break;
		case Border.right	:prisoner.right	=Mathf.Infinity;break;
		}
	}
	void OnEnable(){
		execute();
	}
	void OnDisable(){
		CancelInvoke();
		free();
	}
	void OnDrawGizmos(){
		var direction=border==Border.right?1:-1;
		Gizmos.color=Color.white;
		if(border==Border.right)Gizmos.color=Color.gray;
		Gizmos.DrawCube (transform.position+direction*Vector3.right*(22-15+3), new Vector3 (1,30,30));
		// Gizmos.DrawCube (transform.position, new Vector3 (1,1,1));
	}
}
