using UnityEngine;
using System.Collections;
 #if UNITY_EDITOR
	using UnityEditor;
 #endif
[ExecuteInEditMode]
public class TrnthEditorPlanter : TrnthEditor {
	public GameObject prefab;
	public LayerMask layerMask;
	public LayerMask layerMaskExclude;
	public float space=10;
	[Tooltip("Test")]
	[Range (0, 1)]
	public float perlinScale=1;
	public Vector2 size=new Vector2(10,10);
	[ContextMenu("execute")]
	public void execute(){
		var pointStart=(-Vector3.right*size.x-Vector3.up*size.y)*0.5f;
		
		for(float yy=0;yy<size.y;yy+=space){
		for(float xx=0;xx<size.x;xx+=space){
			if(Random.value<Mathf.PerlinNoise(xx,yy)*perlinScale)continue;
			var pos=transform.TransformPoint(pointStart+(new Vector3(xx,yy,0)));
			RaycastHit hitInfo;
			if(!Physics.Raycast(pos,transform.forward,out hitInfo,100,layerMask.value))continue;
			if(((1<<hitInfo.collider.gameObject.layer)&layerMaskExclude.value)!=0)continue;
			#if UNITY_EDITOR
				GameObject go=PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			#else
				GameObject go=Instantiate(prefab) as GameObject;
			#endif
			go.transform.position=hitInfo.point;
			go.transform.parent=transform;
			go.name=hitInfo.collider.name;
		}}
	}
	// void Update(){
	// 	RaycastHit hitInfo; 
	// 	if(!Physics.Raycast(transform.position,transform.forward,out hitInfo,100,layerMask.value))return;
	// 	prefab.transform.position=hitInfo.point;
	// }
	// Vector3 xxyy;
	// Vector3 _x_y;
	// void boo(){
	// 	Debug.Log("安安");
	// }
	void OnDrawGizmosSelected(){
		Gizmos.color=Color.red;
		Gizmos.DrawRay(transform.position,transform.forward*100);
		var xxyy=(Vector3.right*size.x+Vector3.up*size.y)*0.5f;
		var _x_y=(Vector3.right*size.x+Vector3.up*size.y)*-0.5f;		
		xxyy=transform.TransformPoint(xxyy);
		_x_y=transform.TransformPoint(_x_y);
		Gizmos.DrawLine((xxyy),(_x_y));
		// Gizmos.DrawLine(,);
	}
}
