#pragma strict
var materialAlive:Material;
var material:Material;
var rdr:Renderer;
private var materialOrin:Material;
function excute(){
	if(rdr)rdr.material=material;	
}
function Awake(){
	materialOrin=rdr.material;
}
function OnSpawned(){
	rdr.material=materialOrin;
}
function die(){
	excute();
}