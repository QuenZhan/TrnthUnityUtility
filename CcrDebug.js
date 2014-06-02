#pragma strict

function Start () {

}

function Update () {

}
function OnControllerColliderHit( hit:ControllerColliderHit){
	Debug.Log(hit.gameObject.name);
}
