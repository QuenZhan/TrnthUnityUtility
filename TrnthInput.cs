using UnityEngine;
public class TrnthInput:TrnthMonoBehaviour{	
	public GameObject locator;
	public Transform locatorOnHold;
	public GameObject[] onClick;
	public GameObject[] onHolding;
	public Collider colTarget;
	public TrnthCreature ccc;
	public bool mouseRight;
	public bool hover(){
		return hover(0);
	}
	public bool hover(float dis){
		Ray mspTRay=Camera.main.ScreenPointToRay(Input.mousePosition);
		mspTRay.origin+=mspTRay.direction*dis;
		bool iss=false;
		if(!colTarget)return false;
		iss=colTarget.Raycast(mspTRay,out _hit,100);
		if(iss){
			if(locator)locator.transform.position=_hit.point;
		}
		return iss;
	}
	virtual public bool isHover{
		get{
			return hover(0);
		}
	}
	virtual public bool isClick{
		get{
			return Input.GetMouseButtonDown(0)
				|| (Input.GetMouseButtonDown(1)&&mouseRight)
				||Input.GetKeyDown(KeyCode.LeftShift)
				||Input.GetKeyDown(KeyCode.RightShift)
				||Input.GetKeyDown(KeyCode.Space)
				||Input.GetKeyDown(KeyCode.Z)
				||(Input.touches.Length>0&&Input.touches[0].phase==TouchPhase.Began);
		}
	}
	virtual public bool isDown{
		get{
			return Input.GetMouseButtonDown(0)
				||(Input.GetMouseButtonDown(1)&&mouseRight)
				||Input.GetKeyDown(KeyCode.LeftShift)
				||Input.GetKeyDown(KeyCode.RightShift)
				||Input.GetKeyDown(KeyCode.Space)
				||Input.GetKeyDown(KeyCode.Z)
				||(Input.touches.Length>0&&Input.touches[0].phase==TouchPhase.Began)
				;
		}
	}
	virtual public bool isUp{
		get{
			return Input.GetMouseButtonUp(0)
				||(Input.GetMouseButtonUp(1)&&mouseRight)
				||Input.GetKeyUp(KeyCode.LeftShift)
				||Input.GetKeyUp(KeyCode.RightShift)
				||Input.GetKeyUp(KeyCode.Space)
				||Input.GetKeyUp(KeyCode.Z)
				;
		}
	}
	virtual public bool isHold{
		get{
			// aClick
			return Input.GetMouseButton(0)
				||(Input.GetMouseButton(1)&&mouseRight)
				||Input.GetKey(KeyCode.LeftShift)
				||Input.GetKey(KeyCode.RightShift)
				||Input.GetKey(KeyCode.Space)
				||Input.GetKey(KeyCode.Z)
				||Input.touches.Length>0;
		}
	}
	virtual public bool isCancel{
		get{
			return Input.GetKeyDown(KeyCode.Escape)
				||(Input.GetMouseButtonDown(1)&&mouseRight)
				||Input.GetKeyDown(KeyCode.X);
		}
	}
	virtual public bool isSkip{
		get{
			return Input.GetKey(KeyCode.LeftControl);
		}
	}
	public Vector3 coorMouse{
		get{
			Vector3 coor=Input.touches.Length>0?((Vector3)Input.touches[0].position):Input.mousePosition;
			coor.y=Screen.height-coor.y;
			return coor;
		}
	}
	public RaycastHit hit{
		get{
			return _hit;
		}
	}
	RaycastHit _hit;
	void Update(){
		hover();
		// if(isHold)SendMessage("OnInputHold",SendMessageOptions.DontRequireReceiver);
		if(isDown){
			SendMessage("OnInputDown",SendMessageOptions.DontRequireReceiver);
			foreach(var e in onClick)e.SetActive(true);
		}
		if(isUp)SendMessage("OnInputUp",SendMessageOptions.DontRequireReceiver);
		if(isHold){
			locatorOnHold.position=_hit.point;
		}
		foreach(var e in onHolding)e.SetActive(isHold);
		if(ccc){
			ccc.targetPersitant=isHold?locator:null;
		}
	}
}