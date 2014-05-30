#pragma strict
var material:Material;
var rdr:Renderer;
private var materialOrin:Material;
function excute(){
	if(rdr)rdr.material=material;	
}
function Awake(){
	materialOrin=rdr.material;
}
function OnSpawend(){
	rdr.material=materialOrin;
}
function die(){
	excute();
}