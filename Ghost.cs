using UnityEngine;
using System.Collections;
namespace TRNTH{
// [RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Creature))]
public class Ghost:TRNTH.MonoBehaviour{
	public string command="";

}
}